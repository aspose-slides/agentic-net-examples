using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string presentationPath = "input.pptx";
        string fontPath = "customfont.ttf";
        string pdfOutputPath = "output.pdf";

        // Verify input files exist
        if (!File.Exists(presentationPath))
        {
            Console.WriteLine("Presentation file not found: " + presentationPath);
            return;
        }
        if (!File.Exists(fontPath))
        {
            Console.WriteLine("Font file not found: " + fontPath);
            return;
        }

        try
        {
            // Load custom font bytes
            byte[] fontData = File.ReadAllBytes(fontPath);
            // Register external font with Aspose.Slides
            FontsLoader.LoadExternalFont(fontData);

            // Open presentation
            using (Presentation presentation = new Presentation(presentationPath))
            {
                // Embed the font into the presentation
                presentation.FontsManager.AddEmbeddedFont(fontData, EmbedFontCharacters.All);

                // Prepare PDF options
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.EmbedFullFonts = true; // embed full fonts

                // Save as PDF
                presentation.Save(pdfOutputPath, SaveFormat.Pdf, pdfOptions);
            }

            Console.WriteLine("PDF preview generated successfully.");
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The requested file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., web service errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}