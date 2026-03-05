using System;

class Program
{
    static void Main()
    {
        // Path to the folder containing custom fonts
        string fontFolder = "C:\\CustomFonts\\";
        string[] fontFolders = new string[] { fontFolder };

        // Load custom fonts from the specified folder
        Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

        // Add a text frame with sample text
        Aspose.Slides.ITextFrame textFrame = ((Aspose.Slides.IAutoShape)shape).AddTextFrame("Sample text with custom font");

        // Set font properties for the text
        textFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 24;
        textFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new Aspose.Slides.FontData("CustomFontName");

        // Save the presentation
        presentation.Save("CustomFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clear the font cache
        Aspose.Slides.FontsLoader.ClearCache();
    }
}