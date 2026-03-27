using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the input PPT/PPTX file
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Paths for the output PDF files
        string hiddenInkPdfPath = "output_hidden_ink.pdf";
        string visibleInkPdfPath = "output_visible_ink.pdf";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Create PDF options and hide ink strokes
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
        pdfOptions.InkOptions.HideInk = true;

        // Save PDF with ink hidden
        presentation.Save(hiddenInkPdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Show ink strokes and change mask rendering option
        pdfOptions.InkOptions.HideInk = false;
        pdfOptions.InkOptions.InterpretMaskOpAsOpacity = false;

        // Save PDF with ink visible
        presentation.Save(visibleInkPdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Save the (unchanged) presentation before exiting
        string outputPptxPath = "output_modified.pptx";
        presentation.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}