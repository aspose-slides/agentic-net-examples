using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pdf";

        // Check if the input file exists
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
                // Configure PDF options to export only speaker notes
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions()
                {
                    NotesPosition = NotesPositions.BottomFull
                };

                // Save the presentation as PDF with notes-only layout
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
        }
        catch (PptxUnsupportedFormatException ex)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}