using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load custom fonts from a folder before creating the presentation
            Aspose.Slides.FontsLoader.LoadExternalFonts(new string[] { "C:\\CustomFonts" });

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to hold text
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

            // Add a text frame with sample text
            autoShape.AddTextFrame("Sample text with custom font");

            // Set font properties for the first portion
            autoShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 24;
            autoShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new Aspose.Slides.FontData("MyCustomFont");

            // Embed all fonts used in the presentation
            Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();
            Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

            foreach (Aspose.Slides.IFontData font in allFonts)
            {
                bool alreadyEmbedded = false;
                foreach (Aspose.Slides.IFontData ef in embeddedFonts)
                {
                    if (ef.FontName == font.FontName)
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
            presentation.Save("CustomFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}