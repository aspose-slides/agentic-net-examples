using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfConversionWithMetadata
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputSwfPath = "output.swf";
            string metadataPath = "output.meta.txt";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Configure SWF conversion options
                    Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
                    swfOptions.Compressed = true;
                    swfOptions.ShowHiddenSlides = false;
                    swfOptions.ShowTopPane = true;
                    swfOptions.ShowBottomPane = true;
                    swfOptions.ShowLeftPane = true;
                    swfOptions.ShowFullScreen = true;
                    swfOptions.EnableContextMenu = true;

                    // Save the presentation as SWF with the specified options
                    presentation.Save(outputSwfPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                    // Write conversion parameters to a metadata file alongside the SWF
                    using (StreamWriter writer = new StreamWriter(metadataPath))
                    {
                        writer.WriteLine("Compressed=" + swfOptions.Compressed);
                        writer.WriteLine("ShowHiddenSlides=" + swfOptions.ShowHiddenSlides);
                        writer.WriteLine("ShowTopPane=" + swfOptions.ShowTopPane);
                        writer.WriteLine("ShowBottomPane=" + swfOptions.ShowBottomPane);
                        writer.WriteLine("ShowLeftPane=" + swfOptions.ShowLeftPane);
                        writer.WriteLine("ShowFullScreen=" + swfOptions.ShowFullScreen);
                        writer.WriteLine("EnableContextMenu=" + swfOptions.EnableContextMenu);
                    }

                    // Ensure the presentation is saved before exiting (already saved above)
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The requested format is not supported by Aspose.Slides.
                Console.WriteLine("The SWF format is not supported for the given presentation.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}