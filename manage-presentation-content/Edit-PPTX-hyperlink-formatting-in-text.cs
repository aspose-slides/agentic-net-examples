using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle shape
                Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 150, 150, 50);

                // Cast to AutoShape to access text frame
                Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

                // Add a text frame
                autoShape.AddTextFrame("");

                // Set text
                autoShape.TextFrame.Paragraphs[0].Portions[0].Text = "Visit Aspose";

                // Get HyperlinkManager for the portion
                Aspose.Slides.IHyperlinkManager hyperlinkManager = autoShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;

                // Set external hyperlink
                hyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com");

                // Save the presentation
                presentation.Save("HyperlinkDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}