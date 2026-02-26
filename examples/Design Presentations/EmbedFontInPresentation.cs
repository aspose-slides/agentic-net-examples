using System;

class Program
{
    static void Main()
    {
        // Path to folder containing TrueType font files
        string dataDir = "C:\\Data\\";
        string[] fontFolders = new string[] { dataDir };
        Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a shape with text using a custom TrueType font
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
        autoShape.AddTextFrame("Sample text with custom font");
        // Set the font of the text to the custom TrueType font (e.g., "CustomFont")
        Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
        Aspose.Slides.IPortion portion = paragraph.Portions[0];
        portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("CustomFont");

        // Embed all fonts used in the presentation that are not already embedded
        Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();
        Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

        foreach (Aspose.Slides.IFontData font in allFonts)
        {
            bool alreadyEmbedded = false;
            foreach (Aspose.Slides.IFontData embedded in embeddedFonts)
            {
                if (embedded.FontName == font.FontName)
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

        // Save the presentation
        presentation.Save(dataDir + "EmbeddedFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clear the font cache
        Aspose.Slides.FontsLoader.ClearCache();
    }
}