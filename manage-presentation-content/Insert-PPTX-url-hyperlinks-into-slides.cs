using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                var presentation = new Presentation();

                // Get the first slide
                var slide = presentation.Slides[0];

                // Add a rectangle shape
                var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 50);

                // Cast to IAutoShape to access text frame
                var autoShape = (IAutoShape)shape;

                // Add a text frame and set text
                autoShape.AddTextFrame("Click here to visit Aspose");
                var textFrame = autoShape.TextFrame;
                var portion = textFrame.Paragraphs[0].Portions[0];

                // Set external hyperlink on the portion
                var hyperlinkManager = portion.PortionFormat.HyperlinkManager;
                hyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com");

                // Save the presentation
                presentation.Save("HyperlinkPresentation.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}