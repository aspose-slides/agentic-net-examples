using System;

namespace ConvertPresentationToPdfWithNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Load the source presentation
            Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation(inputPath);

            // Create a new presentation to hold the slide with notes
            using (Aspose.Slides.Presentation auxPresentation = new Aspose.Slides.Presentation())
            {
                // Clone the first slide (you can loop to clone all slides if needed)
                Aspose.Slides.ISlide sourceSlide = sourcePresentation.Slides[0];
                auxPresentation.Slides.InsertClone(0, sourceSlide);

                // Set slide size (optional, matching typical page size)
                auxPresentation.SlideSize.SetSize(612f, 792f, Aspose.Slides.SlideSizeScaleType.EnsureFit);

                // Configure PDF options to include notes at the bottom
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                pdfOptions.SlidesLayoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions()
                {
                    NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull
                };

                // Save the presentation as PDF with notes
                auxPresentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }

            // Dispose the source presentation
            sourcePresentation.Dispose();
        }
    }
}