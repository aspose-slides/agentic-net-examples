using System;

class Program
{
    static void Main(string[] args)
    {
        // Define input PowerPoint file and output PDF file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pdf";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Create PDF options and set layout to include speaker notes at the bottom
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
        pdfOptions.SlidesLayoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions()
        {
            NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull
        };

        // Save the presentation as PDF with notes
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Release resources
        presentation.Dispose();
    }
}