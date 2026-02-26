using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the custom font file
        string fontPath = "C:\\Fonts\\CustomFont.ttf";

        // Load the font data from file
        byte[] fontData = File.ReadAllBytes(fontPath);

        // Register the external font with Aspose.Slides
        Aspose.Slides.FontsLoader.LoadExternalFont(fontData);

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a new slide based on the first layout slide
        Aspose.Slides.ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

        // Add a rectangle shape to the slide
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 200);

        // Add a text frame with sample text
        autoShape.AddTextFrame("Hello with custom font!");

        // Apply the custom font to all portions of the text
        Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
        foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
        {
            portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("Custom Font");
        }

        // Save the presentation
        string outputPath = "C:\\Output\\CustomFontPresentation.pptx";
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clear the font cache
        Aspose.Slides.FontsLoader.ClearCache();

        // Dispose the presentation
        pres.Dispose();
    }
}