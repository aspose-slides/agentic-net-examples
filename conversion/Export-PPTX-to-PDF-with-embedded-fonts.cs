using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPptxToPdfWithEmbeddedFonts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input and output folders (use defaults if not provided)
            string inputFolder = args.Length > 0 ? args[0] : "InputPptx";
            string outputFolder = args.Length > 1 ? args[1] : "OutputPdf";

            // Verify input folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine("Input folder does not exist: " + inputFolder);
                return;
            }

            // Ensure output folder exists
            Directory.CreateDirectory(outputFolder);

            // Process each PPTX file in the input folder
            string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx");
            foreach (string pptxPath in pptxFiles)
            {
                // Verify the file exists (redundant but safe)
                if (!File.Exists(pptxPath))
                {
                    Console.WriteLine("File not found: " + pptxPath);
                    continue;
                }

                try
                {
                    // Load the presentation
                    using (Presentation presentation = new Presentation(pptxPath))
                    {
                        // Embed all fonts that are not already embedded
                        IFontData[] allFonts = presentation.FontsManager.GetFonts();
                        IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

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
                                // Embed the font with all characters
                                presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
                            }
                        }

                        // Configure PDF options to embed full fonts
                        PdfOptions pdfOptions = new PdfOptions();
                        pdfOptions.EmbedFullFonts = true;

                        // Save as PDF
                        string pdfFileName = Path.GetFileNameWithoutExtension(pptxPath) + ".pdf";
                        string pdfPath = Path.Combine(outputFolder, pdfFileName);
                        presentation.Save(pdfPath, SaveFormat.Pdf, pdfOptions);
                        Console.WriteLine("Converted: " + pptxPath + " -> " + pdfPath);
                    }
                }
                catch (PptxUnsupportedFormatException)
                {
                    // Format not supported – skip this file
                    Console.WriteLine("Unsupported file format: " + pptxPath);
                }
                catch (Exception ex)
                {
                    // General exception handling (e.g., I/O errors)
                    Console.WriteLine("Error processing file: " + pptxPath);
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }
        }
    }
}