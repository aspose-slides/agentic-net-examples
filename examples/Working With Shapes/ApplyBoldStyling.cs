using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle shape to the first slide
        Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

        // Add a text frame with sample text
        shape.AddTextFrame("Hello World");

        // Get the first paragraph and its first portion
        Aspose.Slides.IParagraph paragraph = shape.TextFrame.Paragraphs[0];
        Aspose.Slides.IPortion portion = paragraph.Portions[0];

        // Apply bold formatting to the portion
        portion.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;

        // Save the presentation
        presentation.Save("BoldPortion_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}