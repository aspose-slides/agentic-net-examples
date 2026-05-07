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

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                PdfOptions pdfOptions = new PdfOptions();
                NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
                layoutOptions.NotesPosition = NotesPositions.BottomFull;
                pdfOptions.SlidesLayoutOptions = layoutOptions;

                presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
            }
        }
        catch (PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The provided file format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}