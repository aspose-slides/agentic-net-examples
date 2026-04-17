using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace EmbedCustomFonts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to the source presentation and custom font file
            string presentationPath = "input.pptx";
            string fontPath = "customfonts\\MyCustomFont.ttf";
            string outputPath = "output_embedded.pptx";

            // Verify that the source presentation exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Source presentation file not found: " + presentationPath);
                return;
            }

            // Verify that the custom font file exists
            if (!File.Exists(fontPath))
            {
                Console.WriteLine("Custom font file not found: " + fontPath);
                return;
            }

            try
            {
                // Load the custom font into Aspose.Slides font cache
                byte[] fontData = File.ReadAllBytes(fontPath);
                FontsLoader.LoadExternalFont(fontData);

                // Open the presentation
                using (Presentation presentation = new Presentation(presentationPath))
                {
                    // Retrieve all fonts used in the presentation
                    IFontData[] allFonts = presentation.FontsManager.GetFonts();

                    // Attempt to embed each font
                    foreach (IFontData font in allFonts)
                    {
                        try
                        {
                            presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
                        }
                        catch (ArgumentException)
                        {
                            // Font is already embedded; ignore
                        }
                    }

                    // Save the presentation with embedded fonts
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }

                // Clear the font cache after processing
                FontsLoader.ClearCache();

                Console.WriteLine("Presentation saved with embedded fonts: " + outputPath);
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
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