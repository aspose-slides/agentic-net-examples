using System;

namespace AsposeSlidesConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path
            string inputPath = "input.pptx";
            // Output PDF file path
            string outputPath = "output.pdf";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Create PDF options
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

                // Configure notes layout to preserve speaker notes
                Aspose.Slides.Export.NotesCommentsLayoutingOptions notesLayout = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
                notesLayout.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;

                // Assign the notes layout to PDF options
                pdfOptions.SlidesLayoutOptions = notesLayout;

                // Save the presentation as PDF with notes
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
        }
    }
}