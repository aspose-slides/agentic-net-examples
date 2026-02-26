using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 150, 150, 50);

        // Cast the shape to AutoShape to work with text
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

        // Add an empty text frame
        autoShape.AddTextFrame("");

        // Access the text frame
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

        // Set the display text
        textFrame.Paragraphs[0].Portions[0].Text = "Visit Aspose";

        // Obtain the hyperlink manager for the text portion
        Aspose.Slides.IHyperlinkManager hyperlinkManager = textFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;

        // Assign an external hyperlink to be opened on click
        hyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com");

        // Save the presentation in PPT format
        presentation.Save("HyperlinkPresentation.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
    }
}