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
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Ensure each slide has a notes slide and enable slide number visibility on it
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    INotesSlideManager notesManager = slide.NotesSlideManager;
                    INotesSlide notesSlide = notesManager.NotesSlide;
                    if (notesSlide == null)
                    {
                        notesSlide = notesManager.AddNotesSlide();
                    }

                    IBaseSlideHeaderFooterManager notesHeaderFooter = notesSlide.HeaderFooterManager;
                    notesHeaderFooter.SetSlideNumberVisibility(true);
                }

                // Configure PDF export to include notes pages
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions()
                {
                    NotesPosition = NotesPositions.BottomFull
                };

                presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}