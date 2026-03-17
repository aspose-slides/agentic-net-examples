using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Load custom fonts from a folder (ensure the folder contains .ttf or .otf files)
            string[] fontFolders = new string[] { "CustomFonts" };
            Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a rectangle shape with a text frame
            IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            autoShape.AddTextFrame("Sample text with custom font");

            // Apply the custom font to the text
            autoShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("CustomFontName");

            // Embed all fonts used in the presentation
            IFontData[] allFonts = presentation.FontsManager.GetFonts();
            IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

            foreach (IFontData font in allFonts)
            {
                bool alreadyEmbedded = false;
                foreach (IFontData embedded in embeddedFonts)
                {
                    if (embedded.FontName == font.FontName)
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

            // Save the presentation
            presentation.Save("CustomFontPresentation.pptx", SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}