using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertSelectedSlidesToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input file path
            var inputPath = args.Length > 0 && !string.IsNullOrEmpty(args[0]) ? args[0] : "input.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Determine output file path
            var outputPath = Path.ChangeExtension(inputPath, ".pdf");

            try
            {
                // Load presentation
                using (var presentation = new Presentation(inputPath))
                {
                    // Specify slides to include (1-based indices)
                    var slides = new int[] { 1, 3, 5 };

                    // Save selected slides as PDF
                    presentation.Save(outputPath, slides, SaveFormat.Pdf);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}