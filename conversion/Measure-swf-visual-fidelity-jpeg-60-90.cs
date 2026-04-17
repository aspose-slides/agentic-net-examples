using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PowerPoint file
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Create SWF options instance
                    Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

                    // First conversion with JPEG quality 60
                    swfOptions.JpegQuality = 60;
                    string outputPath60 = "output_quality60.swf";
                    presentation.Save(outputPath60, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                    // Second conversion with JPEG quality 90
                    swfOptions.JpegQuality = 90;
                    string outputPath90 = "output_quality90.swf";
                    presentation.Save(outputPath90, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
                }
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}