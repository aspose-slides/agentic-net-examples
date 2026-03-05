using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths to the input and output presentations
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Get all fonts used in the presentation and the fonts already embedded
        Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();
        Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

        // Embed any fonts that are not already embedded
        foreach (Aspose.Slides.IFontData font in allFonts)
        {
            bool isEmbedded = false;
            foreach (Aspose.Slides.IFontData ef in embeddedFonts)
            {
                if (ef.Equals(font))
                {
                    isEmbedded = true;
                    break;
                }
            }
            if (!isEmbedded)
            {
                // Use the correct enum from Aspose.Slides.Export
                presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
            }
        }

        // Save the presentation before exiting
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}