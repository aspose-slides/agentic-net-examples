using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPptxToSwf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.swf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure SWF export options to minimize file size
                    SwfOptions swfOptions = new SwfOptions();
                    // Disable viewer to reduce size
                    swfOptions.ViewerIncluded = false;
                    // Do not show hidden slides
                    swfOptions.ShowHiddenSlides = false;
                    // Optionally disable UI elements to further reduce size
                    swfOptions.ShowBottomPane = false;
                    swfOptions.ShowFullScreen = false;
                    swfOptions.ShowLeftPane = false;
                    swfOptions.ShowPageBorder = false;
                    swfOptions.ShowPageStepper = false;
                    swfOptions.ShowSearch = false;
                    swfOptions.ShowTopPane = false;

                    // Save the presentation as SWF with the specified options
                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                }

                Console.WriteLine("Presentation successfully exported to SWF.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}