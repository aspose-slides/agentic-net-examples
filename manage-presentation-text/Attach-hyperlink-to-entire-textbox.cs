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

        // Add a rectangle auto shape (text box) to the slide
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 150, 300, 100);

        // Cast the shape to IAutoShape to work with text
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
        autoShape.AddTextFrame("Click here");

        // Attach an external hyperlink to the entire text box using HyperlinkManager
        Aspose.Slides.IHyperlink hyperlink = autoShape.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com");

        // Optionally assign the hyperlink to the HyperlinkClick property
        autoShape.HyperlinkClick = hyperlink;

        // Save the presentation
        presentation.Save("HyperlinkedTextBox.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}