using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontEmbeddingXpsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths
            string inputPath = "input.pptx";
            string outputPath = "output.xps";
            string fontFolderPath = "fonts";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file not found: " + inputPath);
                return;
            }

            // Load additional font folder (contains bold styles)
            try
            {
                string[] fontFolders = new string[] { fontFolderPath };
                FontsLoader.LoadExternalFonts(fontFolders);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load external fonts: " + ex.Message);
                // Continue processing even if fonts folder could not be loaded
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Embed all fonts from the presentation that are not already embedded
                IFontData[] allFonts = presentation.FontsManager.GetFonts();
                IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                foreach (IFontData font in allFonts)
                {
                    bool alreadyEmbedded = false;
                    foreach (IFontData embedded in embeddedFonts)
                    {
                        if (embedded.FontName == font.FontName)
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

                // Save the presentation to XPS format to test style preservation
                presentation.Save(outputPath, SaveFormat.Xps);

                // Dispose presentation
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}