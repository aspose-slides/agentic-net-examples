using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("Fonts.pptx");

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
                presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
            }
        }

        // Save the presentation with embedded fonts
        presentation.Save("AddEmbeddedFont_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}