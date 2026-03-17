using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (var presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                var slide = presentation.Slides[0];

                // Add a rectangle shape
                var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 50);
                var autoShape = (Aspose.Slides.IAutoShape)shape;

                // Add a text frame with initial text
                autoShape.AddTextFrame("Click me");
                var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];

                // Set an external hyperlink on click
                var hyperlinkManager = portion.PortionFormat.HyperlinkManager;
                hyperlinkManager.SetExternalHyperlinkClick("https://example.com");

                // Modify the hyperlink to a new URL
                hyperlinkManager.SetExternalHyperlinkClick("https://newexample.com");

                // Delete the hyperlink
                hyperlinkManager.RemoveHyperlinkClick();

                // Save the presentation
                presentation.Save("HyperlinkDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}