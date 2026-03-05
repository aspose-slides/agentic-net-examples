using System;

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

        // Cast to AutoShape to work with text
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

        // Add a text frame with some text
        autoShape.AddTextFrame("Click Here");

        // Access the first portion of the text
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
        Aspose.Slides.IPortion portion = paragraph.Portions[0];

        // Set an external hyperlink on the portion text
        Aspose.Slides.IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;
        Aspose.Slides.IHyperlink hyperlink = hyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com");
        hyperlink.Tooltip = "Aspose website";

        // Save the presentation
        presentation.Save("HyperlinkDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}