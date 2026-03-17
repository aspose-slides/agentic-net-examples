using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExternalImageLinkDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                var presentation = new Presentation();

                // Get the first slide
                var slide = presentation.Slides[0];

                // Add a rectangle shape that will act as a placeholder for the external image
                var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 300);

                // Set a hyperlink on the shape to the external image file (e.g., a local path or URL)
                shape.HyperlinkClick = new Hyperlink("file:///C:/Images/ExternalPicture.jpg");

                // Optionally add a caption
                var autoShape = (IAutoShape)shape;
                autoShape.AddTextFrame("Click to view external image");
                autoShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 18;

                // Save the presentation
                presentation.Save("ExternalImageLinked.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}