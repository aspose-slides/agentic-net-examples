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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle AutoShape
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

            // Cast the shape to AutoShape to work with text
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

            // Add an empty text frame
            autoShape.AddTextFrame("");

            // Access the text frame
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

            // Set the text for the first portion
            textFrame.Paragraphs[0].Portions[0].Text = "Visit Aspose";

            // Get the hyperlink manager for the portion
            Aspose.Slides.IHyperlinkManager hyperlinkManager = textFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;

            // Set an external hyperlink on click
            hyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com");

            // Save the presentation
            presentation.Save("HyperlinkPresentation.pptx", Aspose.Slides.Export.SaveFormat.Ppt);
        }
    }
}