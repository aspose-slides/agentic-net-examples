using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 150, 150, 50);

        // Cast to AutoShape
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

        // Add a text frame with initial text
        autoShape.AddTextFrame("Click here");
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

        // Access the first portion of the first paragraph
        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
        Aspose.Slides.IPortion portion = paragraph.Portions[0];

        // Set an external hyperlink on click
        Aspose.Slides.IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;
        Aspose.Slides.IHyperlink hyperlink = hyperlinkManager.SetExternalHyperlinkClick("http://www.example.com");

        // Modify mutable hyperlink properties
        hyperlink.Tooltip = "Go to example.com";
        hyperlink.History = true;
        hyperlink.HighlightClick = true;

        // Save the presentation
        presentation.Save("MutableHyperlink_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}