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

        // Cast to IAutoShape to access text frame
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

        // Add a text frame and set its text
        autoShape.AddTextFrame("");
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
        textFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

        // Get the hyperlink manager for the text portion
        Aspose.Slides.IHyperlinkManager hyperlinkManager = textFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;

        // Set an external hyperlink on click
        Aspose.Slides.IHyperlink externalLink = hyperlinkManager.SetExternalHyperlinkClick("http://www.aspose.com");

        // Add a second slide to demonstrate changing to an internal hyperlink
        Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

        // Change the hyperlink to point to the second slide (internal hyperlink)
        Aspose.Slides.IHyperlink internalLink = hyperlinkManager.SetInternalHyperlinkClick(secondSlide);

        // Save the presentation in PPT format
        presentation.Save("MutableHyperlink_out.ppt", Aspose.Slides.Export.SaveFormat.Ppt);

        // Clean up resources
        presentation.Dispose();
    }
}