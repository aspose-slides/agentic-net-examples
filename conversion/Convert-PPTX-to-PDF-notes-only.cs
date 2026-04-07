using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        var inputPath = "input.pptx";
        var outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            using (var pres = new Presentation(inputPath))
            {
                // Configure PDF options to include only speaker notes
                var pdfOptions = new PdfOptions
                {
                    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
                    {
                        NotesPosition = NotesPositions.BottomFull
                    }
                };

                // Save as PDF with notes layout
                pres.Save(outputPath, SaveFormat.Pdf, pdfOptions);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., external URLs or web services)
        }
    }
}