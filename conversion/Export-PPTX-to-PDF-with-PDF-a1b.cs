using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPdfA1b
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Embed all fonts used in the presentation
                    IFontData[] allFonts = presentation.FontsManager.GetFonts();
                    IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
                    foreach (IFontData font in allFonts)
                    {
                        bool alreadyEmbedded = false;
                        foreach (IFontData ef in embeddedFonts)
                        {
                            if (ef.FontName.Equals(font.FontName, StringComparison.OrdinalIgnoreCase))
                            {
                                alreadyEmbedded = true;
                                break;
                            }
                        }
                        if (!alreadyEmbedded)
                        {
                            presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
                        }
                    }

                    // Configure PDF options for PDF/A‑1b compliance and full font embedding
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.Compliance = PdfCompliance.PdfA1b;
                    pdfOptions.EmbedFullFonts = true;

                    // Save the presentation as PDF/A‑1b
                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
                }

                Console.WriteLine("Presentation successfully exported to PDF/A‑1b: " + outputPath);
            }
            catch (PptxUnsupportedFormatException ex)
            {
                // Handle unsupported file format
                Console.WriteLine("Unsupported file format: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}