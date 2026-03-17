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

                // Add a rectangle auto shape
                Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 150, 300, 50);

                // Cast to AutoShape to work with text
                Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

                // Add a text frame with initial text
                autoShape.AddTextFrame("Click here");

                // Access the first portion of the text
                Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
                Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
                Aspose.Slides.IPortion portion = paragraph.Portions[0];

                // Set an external hyperlink on the portion
                Aspose.Slides.IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;
                hyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com");

                // Save the presentation
                presentation.Save("HyperlinkPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}