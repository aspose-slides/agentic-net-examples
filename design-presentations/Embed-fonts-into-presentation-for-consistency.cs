using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace EmbeddedFontsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Retrieve all fonts used in the presentation
                Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();

                // Retrieve fonts already embedded
                Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                // Embed missing fonts
                foreach (Aspose.Slides.IFontData font in allFonts)
                {
                    bool alreadyEmbedded = false;
                    foreach (Aspose.Slides.IFontData embedded in embeddedFonts)
                    {
                        if (embedded.Equals(font))
                        {
                            alreadyEmbedded = true;
                            break;
                        }
                    }

                    if (!alreadyEmbedded)
                    {
                        presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
                    }
                }

                // Save the presentation with embedded fonts
                presentation.Save("EmbeddedFontsPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}