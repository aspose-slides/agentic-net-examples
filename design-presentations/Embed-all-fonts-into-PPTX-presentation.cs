using System;
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
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Get all fonts used in the presentation
                IFontData[] allFonts = presentation.FontsManager.GetFonts();

                // Get fonts already embedded
                IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                // Embed missing fonts
                foreach (IFontData font in allFonts)
                {
                    bool alreadyEmbedded = false;
                    foreach (IFontData embedded in embeddedFonts)
                    {
                        if (embedded.Equals(font))
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

                // Save the presentation with all fonts embedded
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}