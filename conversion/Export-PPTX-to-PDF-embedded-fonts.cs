using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPptxToPdfWithEmbeddedFonts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Folder containing PPTX files; can be passed as first argument
            string folderPath = args.Length > 0 ? args[0] : "InputPptx";

            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"Folder not found: {folderPath}");
                return;
            }

            string[] pptxFiles = Directory.GetFiles(folderPath, "*.pptx");

            foreach (string pptxFile in pptxFiles)
            {
                try
                {
                    using (Presentation presentation = new Presentation(pptxFile))
                    {
                        // Embed all fonts used in the presentation
                        IFontData[] allFonts = presentation.FontsManager.GetFonts();
                        IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                        foreach (IFontData font in allFonts)
                        {
                            bool isAlreadyEmbedded = embeddedFonts.Any(ef => ef.Equals(font));
                            if (!isAlreadyEmbedded)
                            {
                                presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
                            }
                        }

                        // Set PDF options to embed full fonts
                        PdfOptions pdfOptions = new PdfOptions();
                        pdfOptions.EmbedFullFonts = true;

                        // Save as PDF in the same folder
                        string pdfPath = Path.ChangeExtension(pptxFile, ".pdf");
                        presentation.Save(pdfPath, SaveFormat.Pdf, pdfOptions);
                    }
                }
                catch (PptxUnsupportedFormatException)
                {
                    // Format not supported
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing '{pptxFile}': {ex.Message}");
                }
            }
        }
    }
}