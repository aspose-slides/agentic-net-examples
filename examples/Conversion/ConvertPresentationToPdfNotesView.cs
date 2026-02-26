using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesToPdfNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the source PowerPoint presentation
            Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation("input.pptx");

            // Create a new presentation that will contain only the notes view
            Aspose.Slides.Presentation auxPresentation = new Aspose.Slides.Presentation();

            // Clone each slide from the source into the auxiliary presentation
            for (int i = 0; i < sourcePresentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = sourcePresentation.Slides[i];
                auxPresentation.Slides.InsertClone(i, slide);
            }

            // Set the slide size (optional, matches example dimensions)
            auxPresentation.SlideSize.SetSize(612f, 792f, Aspose.Slides.SlideSizeScaleType.EnsureFit);

            // Configure PDF options to export notes below each slide
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.SlidesLayoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions()
            {
                NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull
            };

            // Save the auxiliary presentation as PDF with notes
            auxPresentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            // Dispose presentations
            sourcePresentation.Dispose();
            auxPresentation.Dispose();
        }
    }
}