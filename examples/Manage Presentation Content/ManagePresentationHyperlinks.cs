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
        Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

        // Add a rectangle shape to the first slide
        Aspose.Slides.IShape shape1 = firstSlide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 150, 150, 150, 50);

        // Cast the shape to AutoShape to work with text
        Aspose.Slides.IAutoShape autoShape1 = (Aspose.Slides.IAutoShape)shape1;

        // Add an empty text frame
        autoShape1.AddTextFrame("");

        // Access the text frame
        Aspose.Slides.ITextFrame textFrame1 = autoShape1.TextFrame;

        // Set the display text
        textFrame1.Paragraphs[0].Portions[0].Text = "Visit Aspose";

        // Obtain the hyperlink manager for the text portion
        Aspose.Slides.IHyperlinkManager hyperlinkManager1 = textFrame1.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;

        // Assign an external hyperlink (click action)
        hyperlinkManager1.SetExternalHyperlinkClick("https://www.aspose.com");

        // Add a second slide to the presentation
        Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

        // Add another rectangle shape on the first slide that links to the second slide
        Aspose.Slides.IShape shape2 = firstSlide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 350, 150, 150, 50);

        Aspose.Slides.IAutoShape autoShape2 = (Aspose.Slides.IAutoShape)shape2;
        autoShape2.AddTextFrame("");
        Aspose.Slides.ITextFrame textFrame2 = autoShape2.TextFrame;
        textFrame2.Paragraphs[0].Portions[0].Text = "Go to Slide 2";

        Aspose.Slides.IHyperlinkManager hyperlinkManager2 = textFrame2.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;

        // Assign an internal hyperlink that points to the second slide
        hyperlinkManager2.SetInternalHyperlinkClick(secondSlide);

        // Save the presentation in PPT format
        presentation.Save("HyperlinksDemo.ppt", Aspose.Slides.Export.SaveFormat.Ppt);

        // Clean up resources
        presentation.Dispose();
    }
}