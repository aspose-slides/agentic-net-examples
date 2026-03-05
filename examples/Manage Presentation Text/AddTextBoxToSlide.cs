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

        // Add a rectangle AutoShape that will serve as the text box
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 150, 75, 150, 50);

        // Add an empty TextFrame to the shape
        autoShape.AddTextFrame(" ");

        // Access the TextFrame and its first paragraph and portion
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
        Aspose.Slides.IPortion portion = paragraph.Portions[0];

        // Set the desired text
        portion.Text = "Aspose TextBox";

        // Save the presentation to a PPTX file
        presentation.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}