using System;

class Program
{
    static void Main(string[] args)
    {
        // Specify folders that contain custom fonts
        string[] fontFolders = new string[] { "customfonts" };
        // Load custom fonts from the specified folders before creating any presentation objects
        Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape with a text frame
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
        autoShape.AddTextFrame("Sample text with custom font");

        // Set the font of the text to a custom font
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
        textFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new Aspose.Slides.FontData("CustomFont1");
        textFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 24;

        // Save the presentation
        presentation.Save("CustomFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}