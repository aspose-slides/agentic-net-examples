using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ValidateSwfHiddenThumbnails
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
                    // Create SWF options with hidden slides excluded
                    SwfOptions swfOptions = new SwfOptions();
                    swfOptions.ShowHiddenSlides = false;

                    // Output the number of hidden slides in the source presentation
                    int hiddenSlideCount = presentation.DocumentProperties.HiddenSlides;
                    Console.WriteLine("Hidden slides in source presentation: " + hiddenSlideCount);

                    // Save the presentation as SWF using the specified options
                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                    Console.WriteLine("SWF file saved successfully without hidden slide thumbnails.");
                }
            }
            catch (NotSupportedException ex)
            {
                // Handle unsupported format exception
                Console.WriteLine("Format not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., file access issues, web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}