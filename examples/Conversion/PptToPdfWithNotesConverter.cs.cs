using System;

namespace AsposeSlidesConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Convert PPT file to PDF with notes
            System.String inputPptPath = "example.ppt";
            System.String outputPdfFromPpt = "example_from_ppt.pdf";

            Aspose.Slides.Presentation presentationPpt = new Aspose.Slides.Presentation(inputPptPath);
            Aspose.Slides.Export.PdfOptions pdfOptionsPpt = new Aspose.Slides.Export.PdfOptions();
            Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptionsPpt = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
            notesOptionsPpt.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
            pdfOptionsPpt.SlidesLayoutOptions = notesOptionsPpt;
            presentationPpt.Save(outputPdfFromPpt, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptionsPpt);
            presentationPpt.Dispose();

            // Convert PPTX file to PDF with notes
            System.String inputPptxPath = "example.pptx";
            System.String outputPdfFromPptx = "example_from_pptx.pdf";

            Aspose.Slides.Presentation presentationPptx = new Aspose.Slides.Presentation(inputPptxPath);
            Aspose.Slides.Export.PdfOptions pdfOptionsPptx = new Aspose.Slides.Export.PdfOptions();
            Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptionsPptx = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
            notesOptionsPptx.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
            pdfOptionsPptx.SlidesLayoutOptions = notesOptionsPptx;
            presentationPptx.Save(outputPdfFromPptx, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptionsPptx);
            presentationPptx.Dispose();
        }
    }
}