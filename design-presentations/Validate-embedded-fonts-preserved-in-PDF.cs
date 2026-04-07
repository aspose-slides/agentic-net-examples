using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPdfPath = "output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.IFontData[] embeddedFonts = pres.FontsManager.GetEmbeddedFonts();

            Console.WriteLine("Number of embedded fonts before PDF conversion: " + embeddedFonts.Length);

            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.DefaultRegularFont = "Arial";

            pres.Save(outputPdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            pres.Dispose();

            Console.WriteLine("Presentation saved to PDF with default fonts.");
        }
        catch (Exception ex)
        {
            // If the file format is not supported, handle accordingly
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}