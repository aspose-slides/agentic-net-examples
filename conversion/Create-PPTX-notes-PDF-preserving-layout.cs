using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesToPdfNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Presentation presentation = new Presentation("input.pptx");

                // Configure PDF options to include notes
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions()
                {
                    NotesPosition = NotesPositions.BottomFull
                };

                // Save as PDF with notes
                presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}