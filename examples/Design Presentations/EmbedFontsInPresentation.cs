using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("Fonts.pptx"))
            {
                // Get all fonts used in the presentation
                Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();
                // Get fonts already embedded
                Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                // Embed fonts that are not already embedded
                foreach (Aspose.Slides.IFontData font in allFonts)
                {
                    if (System.Array.IndexOf(embeddedFonts, font) < 0)
                    {
                        presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
                    }
                }

                // Save the presentation with embedded fonts
                presentation.Save("AddEmbeddedFont_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}