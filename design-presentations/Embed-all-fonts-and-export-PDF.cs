using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace EmbedAllFontsAndExportPdf
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
                    // Retrieve all fonts used in the presentation
                    IFontData[] allFonts = presentation.FontsManager.GetFonts();

                    // Retrieve fonts that are already embedded
                    IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                    // Embed each font that is not already embedded
                    foreach (IFontData font in allFonts)
                    {
                        bool isEmbedded = false;
                        foreach (IFontData embeddedFont in embeddedFonts)
                        {
                            if (embeddedFont.Equals(font))
                            {
                                isEmbedded = true;
                                break;
                            }
                        }

                        if (!isEmbedded)
                        {
                            // Embed the full set of characters for the font
                            presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
                        }
                    }

                    // Configure PDF export options to embed all fonts
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.EmbedFullFonts = true;

                    // Save the presentation as PDF with the specified options
                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
                }

                Console.WriteLine("Presentation successfully saved as PDF: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}