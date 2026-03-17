using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Configure PDF options to include speaker notes
            PdfOptions pdfOptions = new PdfOptions();
            pdfOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions()
            {
                NotesPosition = NotesPositions.BottomFull
            };

            // Save the presentation as PDF with notes
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}