using System;

class Program
{
    static void Main(string[] args)
    {
        // Load custom fonts from folder
        string[] fontFolders = new string[] { "customfonts" };
        Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle autoshape
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

        // Add text to the shape
        autoShape.AddTextFrame("Hello with custom font");

        // Set custom font for the text
        Aspose.Slides.IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
        portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("MyCustomFont");

        // Save the presentation
        presentation.Save("CustomFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clear font cache
        Aspose.Slides.FontsLoader.ClearCache();
    }
}