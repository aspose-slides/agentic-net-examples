using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MutableHyperlinkDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation and add a shape with an external hyperlink
                using (Presentation presentation = new Presentation())
                {
                    var slide = presentation.Slides[0];
                    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 50);
                    var autoShape = (IAutoShape)shape;
                    autoShape.AddTextFrame("Click me");
                    var textFrame = autoShape.TextFrame;
                    var portion = textFrame.Paragraphs[0].Portions[0];
                    var hyperlinkManager = portion.PortionFormat.HyperlinkManager;
                    hyperlinkManager.SetExternalHyperlinkClick("https://example.com");

                    // Save the initial presentation
                    presentation.Save("MutableLink.pptx", SaveFormat.Pptx);
                }

                // Load the presentation and update the hyperlink to a new URL
                using (Presentation presentation = new Presentation("MutableLink.pptx"))
                {
                    var slide = presentation.Slides[0];
                    var shape = slide.Shapes[0];
                    var autoShape = (IAutoShape)shape;
                    var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
                    var hyperlinkManager = portion.PortionFormat.HyperlinkManager;
                    hyperlinkManager.SetExternalHyperlinkClick("https://newexample.com");

                    // Save the updated presentation
                    presentation.Save("MutableLinkUpdated.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}