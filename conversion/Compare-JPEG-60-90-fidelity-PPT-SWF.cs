using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfQualityComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Save with JPEG quality 60
                SwfOptions optionsQuality60 = new SwfOptions();
                optionsQuality60.JpegQuality = 60;
                string outputPath60 = "output_quality60.swf";
                presentation.Save(outputPath60, SaveFormat.Swf, optionsQuality60);

                // Save with JPEG quality 90
                SwfOptions optionsQuality90 = new SwfOptions();
                optionsQuality90.JpegQuality = 90;
                string outputPath90 = "output_quality90.swf";
                presentation.Save(outputPath90, SaveFormat.Swf, optionsQuality90);

                // Dispose the presentation
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}