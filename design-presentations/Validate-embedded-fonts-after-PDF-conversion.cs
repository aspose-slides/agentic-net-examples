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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Embed all fonts that are not already embedded
            Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();
            Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
            foreach (Aspose.Slides.IFontData font in allFonts)
            {
                bool isEmbedded = false;
                foreach (Aspose.Slides.IFontData ef in embeddedFonts)
                {
                    if (ef.Equals(font))
                    {
                        isEmbedded = true;
                        break;
                    }
                }
                if (!isEmbedded)
                {
                    presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
                }
            }

            // Save to PDF with default regular font and full font embedding
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.DefaultRegularFont = "Arial";
            pdfOptions.EmbedFullFonts = true;
            presentation.Save(outputPdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            // Validate that embedded fonts are still present
            Aspose.Slides.IFontData[] embeddedAfter = presentation.FontsManager.GetEmbeddedFonts();
            Console.WriteLine("Number of embedded fonts after PDF conversion: " + embeddedAfter.Length);

            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}