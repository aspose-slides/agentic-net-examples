using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 50);

            // Cast to IAutoShape to add text
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
            autoShape.AddTextFrame("Click Here");

            // Set external hyperlink on the shape
            shape.HyperlinkClick = new Aspose.Slides.Hyperlink("https://www.example.com");
            shape.HyperlinkClick.Tooltip = "Go to example.com";

            // Save the presentation
            presentation.Save("HyperlinkedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}