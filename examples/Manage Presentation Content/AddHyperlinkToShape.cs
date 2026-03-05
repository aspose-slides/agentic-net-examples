using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a rectangle shape
            IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

            // Cast to IAutoShape to add text
            IAutoShape autoShape = (IAutoShape)shape;
            autoShape.AddTextFrame("Click Here");

            // Access the text frame and first portion
            ITextFrame textFrame = autoShape.TextFrame;
            IPortion portion = textFrame.Paragraphs[0].Portions[0];

            // Set external hyperlink on click
            IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;
            hyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com");

            // Save the presentation
            presentation.Save("HyperlinkDemo.pptx", SaveFormat.Pptx);
        }
    }
}