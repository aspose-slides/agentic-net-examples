using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 100);

        // Add a text frame with placeholder text
        Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame("Placeholder");

        // Get the first paragraph
        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

        // Get the first portion
        Aspose.Slides.IPortion portion = paragraph.Portions[0];

        // Set the text of the portion
        portion.Text = "Hello, Aspose!";

        // Save the presentation
        presentation.Save("Output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}