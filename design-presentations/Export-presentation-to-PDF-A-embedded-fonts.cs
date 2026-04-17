using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPresentationToPdfA
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Embed all fonts used in the presentation
                    IFontsManager fontsManager = presentation.FontsManager;
                    IFontData[] allFonts = fontsManager.GetFonts();
                    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

                    foreach (IFontData font in allFonts)
                    {
                        bool isAlreadyEmbedded = false;
                        foreach (IFontData embeddedFont in embeddedFonts)
                        {
                            if (embeddedFont.Equals(font))
                            {
                                isAlreadyEmbedded = true;
                                break;
                            }
                        }

                        if (!isAlreadyEmbedded)
                        {
                            fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
                        }
                    }

                    // Set PDF/A options
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.Compliance = PdfCompliance.PdfA1b; // PDF/A compliance
                    pdfOptions.EmbedFullFonts = true; // Embed full fonts for archival

                    // Save the presentation as PDF/A
                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Comment: format not supported
                Console.WriteLine("The presentation format is not supported for PDF/A conversion.");
            }
        }
    }
}