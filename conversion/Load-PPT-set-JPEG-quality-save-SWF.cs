using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesSwfExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.ppt";
            string outputPathFirst = "output_first.swf";
            string outputPathSecond = "output_second.swf";

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
                    // Example of setting JPEG quality (applies to the whole presentation)
                    // If per‑slide JPEG quality were supported, it would be set here per slide.
                    // For demonstration, we set a quality value before each save.

                    // First save with lower JPEG quality and viewer excluded
                    SwfOptions swfOptionsFirst = new SwfOptions();
                    swfOptionsFirst.JpegQuality = 70; // lower quality
                    swfOptionsFirst.ViewerIncluded = false;
                    presentation.Save(outputPathFirst, SaveFormat.Swf, swfOptionsFirst);

                    // Second save with higher JPEG quality and viewer included
                    SwfOptions swfOptionsSecond = new SwfOptions();
                    swfOptionsSecond.JpegQuality = 95; // higher quality
                    swfOptionsSecond.ViewerIncluded = true;
                    presentation.Save(outputPathSecond, SaveFormat.Swf, swfOptionsSecond);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported for saving.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., loading errors, I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}