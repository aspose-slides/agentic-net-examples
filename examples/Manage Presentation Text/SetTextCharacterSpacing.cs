using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetCharacterSpacing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to the slide
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 150, 300, 50);

            // Add a text frame with sample text
            autoShape.AddTextFrame("Sample Text");

            // Access the first portion of the text
            Aspose.Slides.IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];

            // Set character spacing (in points)
            portion.PortionFormat.Spacing = 2f;

            // Save the presentation
            presentation.Save("CharacterSpacing_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}