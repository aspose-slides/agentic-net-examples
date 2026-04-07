using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPdfWithBookmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Export to PDF (Aspose.Slides automatically creates bookmarks from slide titles)
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("Presentation exported to PDF successfully.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The specified format is not supported for saving.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues, corrupted file)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}