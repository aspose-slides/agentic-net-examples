using System;
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

        // Add a rectangle auto shape
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 150, 150, 50);

        // Cast to IAutoShape to work with text
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

        // Add an empty text frame
        autoShape.AddTextFrame("");

        // Get the text frame
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

        // Set the text for the portion
        textFrame.Paragraphs[0].Portions[0].Text = "Visit Aspose";

        // Get the hyperlink manager for the portion
        Aspose.Slides.IHyperlinkManager hyperlinkManager = textFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;

        // Set an external hyperlink on click
        hyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com");

        // Save the presentation in PPT format
        presentation.Save("HyperlinkPresentation.ppt", Aspose.Slides.Export.SaveFormat.Ppt);

        // Dispose the presentation object
        presentation.Dispose();
    }
}