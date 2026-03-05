using System;

class Program
{
    static void Main()
    {
        // Input PowerPoint file and output PDF file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pdf";

        // Load the source presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Create a new presentation to hold the slide with notes
            using (Aspose.Slides.Presentation auxPresentation = new Aspose.Slides.Presentation())
            {
                // Clone the first slide (including its notes) into the new presentation
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                auxPresentation.Slides.InsertClone(0, slide);

                // Set slide size (optional, ensures proper layout)
                auxPresentation.SlideSize.SetSize(612f, 792f, Aspose.Slides.SlideSizeScaleType.EnsureFit);

                // Configure PDF options to include notes at the bottom of each page
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                pdfOptions.SlidesLayoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions()
                {
                    NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull
                };

                // Save the new presentation as a PDF with notes
                auxPresentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
        }
    }
}