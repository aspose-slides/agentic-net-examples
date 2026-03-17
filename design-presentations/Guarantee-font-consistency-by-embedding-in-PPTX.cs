using System;
using Aspose.Slides.Export;

namespace EmbedFontsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("Input.pptx");

                // Retrieve all fonts used in the presentation
                Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();

                // Retrieve fonts that are already embedded
                Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                // Embed fonts that are not yet embedded
                foreach (Aspose.Slides.IFontData font in allFonts)
                {
                    bool isEmbedded = false;
                    foreach (Aspose.Slides.IFontData embedded in embeddedFonts)
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

                // Save the presentation with embedded fonts
                presentation.Save("Output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}