using Aspose.Slides;
using Aspose.Slides.Export;
using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape that will contain the text box
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 150, 150, 150, 50);

            // Cast the shape to AutoShape to access text frame functionality
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

            // Add an empty text frame
            autoShape.AddTextFrame("");

            // Access the text frame
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

            // Set the display text
            textFrame.Paragraphs[0].Portions[0].Text = "Visit Aspose";

            // Obtain the hyperlink manager for the portion and set an external hyperlink
            Aspose.Slides.IHyperlinkManager hyperlinkManager = textFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
            hyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com");

            // Save the modified presentation as PPTX
            presentation.Save("HyperlinkedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}