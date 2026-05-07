using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AdjustSwfJpegQuality
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.swf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Determine slide resolution (area) to decide JPEG quality
                float slideWidth = presentation.SlideSize.Size.Width;
                float slideHeight = presentation.SlideSize.Size.Height;
                float slideArea = slideWidth * slideHeight;

                // Default JPEG quality
                int jpegQuality = 95;

                // Adjust quality based on resolution
                if (slideArea > 3000f * 2000f) // Very high resolution
                {
                    jpegQuality = 60;
                }
                else if (slideArea > 2000f * 1500f) // High resolution
                {
                    jpegQuality = 80;
                }
                // else keep default quality

                // Configure SWF options with dynamic JPEG quality
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.JpegQuality = jpegQuality;

                // Save presentation as SWF with the configured options
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                presentation.Dispose();

                Console.WriteLine("Presentation saved as SWF with JPEG quality: " + jpegQuality);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
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