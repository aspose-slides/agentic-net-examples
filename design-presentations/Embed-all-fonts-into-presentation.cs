using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace EmbedAllFontsExample
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

                // Get fonts already embedded
                IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                // Embed fonts that are not yet embedded
                foreach (IFontData font in allFonts)
                {
                    bool isEmbedded = embeddedFonts.Any(f => f.FontName == font.FontName);
                    if (!isEmbedded)
                    {
                        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
                    }
                }

                // Save the presentation with all fonts embedded
                presentation.Save("AllFontsEmbedded.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}