using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CompressEmbeddedFonts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_compressed.pptx";

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
                    // Get the fonts manager
                    IFontsManager fontsManager = presentation.FontsManager;

                    // Retrieve all fonts used in the presentation
                    IFontData[] allFonts = fontsManager.GetFonts();

                    // Retrieve fonts that are already embedded
                    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

                    // Embed each font with only the used characters to reduce size
                    foreach (IFontData font in allFonts)
                    {
                        bool alreadyEmbedded = false;
                        foreach (IFontData embeddedFont in embeddedFonts)
                        {
                            if (embeddedFont.Equals(font))
                            {
                                alreadyEmbedded = true;
                                break;
                            }
                        }

                        if (!alreadyEmbedded)
                        {
                            fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.OnlyUsed);
                        }
                    }

                    // Save the compressed presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation saved with compressed embedded fonts: " + outputPath);
            }
            catch (PptxUnsupportedFormatException)
            {
                // Handle unsupported file format
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}