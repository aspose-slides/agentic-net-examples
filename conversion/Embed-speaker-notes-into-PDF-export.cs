using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the source presentation
            Presentation presentation = new Presentation("input.pptx");

            // Configure PDF export options to embed speaker notes
            PdfOptions pdfOptions = new PdfOptions();
            pdfOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions()
            {
                NotesPosition = NotesPositions.BottomFull
            };

            // Save the presentation as PDF with notes embedded
            presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}