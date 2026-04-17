using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ValidateEmbeddedFonts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    IFontsManager fontsManager = presentation.FontsManager;

                    // Get all fonts used in the presentation
                    IFontData[] allFonts = fontsManager.GetFonts();

                    // Get fonts that are already embedded
                    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

                    // Find fonts that are not embedded
                    List<IFontData> missingFonts = new List<IFontData>();
                    foreach (IFontData font in allFonts)
                    {
                        bool isEmbedded = false;
                        foreach (IFontData embedded in embeddedFonts)
                        {
                            if (embedded.FontName == font.FontName)
                            {
                                isEmbedded = true;
                                break;
                            }
                        }
                        if (!isEmbedded)
                        {
                            missingFonts.Add(font);
                        }
                    }

                    // Report missing embeddings
                    if (missingFonts.Count == 0)
                    {
                        Console.WriteLine("All fonts are embedded.");
                    }
                    else
                    {
                        Console.WriteLine("Missing embedded fonts:");
                        foreach (IFontData missing in missingFonts)
                        {
                            Console.WriteLine("- " + missing.FontName);
                        }
                    }

                    // Save the presentation before exiting
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            // Handle unsupported format exceptions
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            // General exception handling
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}