using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace EmbedAllFontsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get all fonts used in the presentation
                IFontData[] allFonts = presentation.FontsManager.GetFonts();

                // Get already embedded fonts
                IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                // Embed any missing fonts with all characters
                foreach (IFontData font in allFonts)
                {
                    bool isEmbedded = false;
                    foreach (IFontData embedded in embeddedFonts)
                    {
                        if (embedded.Equals(font))
                        {
                            isEmbedded = true;
                            break;
                        }
                    }

                    if (!isEmbedded)
                    {
                        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
                    }
                }

                // Save the presentation with all fonts embedded
                presentation.Save("EmbeddedFontsPresentation.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}