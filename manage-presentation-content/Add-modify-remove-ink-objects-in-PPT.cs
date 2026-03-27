using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define file paths
        string inputPath = "input.pptx";
        string hiddenPdfPath = "output_hidden.pdf";
        string visiblePdfPath = "output_visible.pdf";

        // Verify that the input presentation exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Create PDF export options
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

        // Hide ink and save PDF
        pdfOptions.InkOptions.HideInk = true;
        presentation.Save(hiddenPdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Show ink, adjust mask opacity, and save another PDF
        pdfOptions.InkOptions.HideInk = false;
        pdfOptions.InkOptions.InterpretMaskOpAsOpacity = false;
        presentation.Save(visiblePdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Save the (potentially modified) presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}