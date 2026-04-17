using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

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

                // Set up PDF options to include notes in the output
                PdfOptions pdfOptions = new PdfOptions();
                NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
                notesOptions.NotesPosition = NotesPositions.BottomFull;
                pdfOptions.SlidesLayoutOptions = notesOptions;

                // Apply grayscale filter to note images (conceptual – actual API may vary)
                // Note: Aspose.Slides does not provide a direct property for grayscale conversion of note images.
                // This placeholder indicates where such processing would be applied if available.

                // Save the presentation as PDF with notes
                presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("Presentation exported to PDF successfully.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported for conversion.
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors, Aspose.Slides errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}