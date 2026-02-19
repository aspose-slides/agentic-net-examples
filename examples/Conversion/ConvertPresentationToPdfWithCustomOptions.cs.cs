using System;

class Program
{
    static void Main()
    {
        // Input and output file paths
        System.String inputPath = "input.pptx";
        System.String outputPath = "output.pdf";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Set custom PDF conversion options
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
        pdfOptions.JpegQuality = 90; // JPEG quality
        pdfOptions.SaveMetafilesAsPng = true; // Save metafiles as PNG
        pdfOptions.TextCompression = Aspose.Slides.Export.PdfTextCompression.Flate; // Text compression
        pdfOptions.Compliance = Aspose.Slides.Export.PdfCompliance.PdfA1b; // PDF compliance level

        // Set notes/comments layout options
        Aspose.Slides.Export.NotesCommentsLayoutingOptions layoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
        layoutOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
        pdfOptions.SlidesLayoutOptions = layoutOptions;

        // Save the presentation as PDF with the custom options
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Dispose the presentation
        presentation.Dispose();
    }
}