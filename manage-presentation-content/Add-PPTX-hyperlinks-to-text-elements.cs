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
                // Load an existing presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Get the first slide (preserve its layout)
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle shape to hold the text (layout remains unchanged)
                Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 50);
                Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

                // Create a text frame and set initial text
                autoShape.AddTextFrame("Click here to visit Aspose");
                Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

                // Access the first paragraph and first portion
                Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
                Aspose.Slides.IPortion portion = paragraph.Portions[0];

                // Set the hyperlink on the portion
                Aspose.Slides.IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;
                hyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com");

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}