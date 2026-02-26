using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load custom font from file
        string fontPath = "customfont.ttf";
        byte[] fontData = System.IO.File.ReadAllBytes(fontPath);
        Aspose.Slides.FontsLoader.LoadExternalFont(fontData);

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a new slide based on the layout of the first slide
        Aspose.Slides.ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

        // Add a rectangle AutoShape and a TextFrame
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 50);
        autoShape.AddTextFrame("Sample Text");

        // Apply the custom font to all portions in the paragraph
        Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
        foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
        {
            portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("CustomFontName");
        }

        // Save the presentation
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clear the font cache
        Aspose.Slides.FontsLoader.ClearCache();
    }
}