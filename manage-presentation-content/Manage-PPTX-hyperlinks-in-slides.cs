using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a rectangle shape
                    IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 50);

                    // Cast to AutoShape to work with text
                    IAutoShape autoShape = (IAutoShape)shape;

                    // Add a text frame and set initial text
                    autoShape.AddTextFrame("Click me");
                    ITextFrame textFrame = autoShape.TextFrame;
                    IParagraph paragraph = textFrame.Paragraphs[0];
                    IPortion portion = paragraph.Portions[0];

                    // Set an external hyperlink on click
                    IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;
                    hyperlinkManager.SetExternalHyperlinkClick("https://example.com");

                    // Modify the hyperlink to a different URL
                    hyperlinkManager.SetExternalHyperlinkClick("https://newexample.com");

                    // Remove the hyperlink
                    hyperlinkManager.RemoveHyperlinkClick();

                    // Save the presentation before exiting
                    presentation.Save("HyperlinkDemo.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}