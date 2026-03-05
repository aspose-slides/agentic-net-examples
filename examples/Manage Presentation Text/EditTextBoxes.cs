using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape as a text box
        Aspose.Slides.IAutoShape textBox = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 100);
        // Add a text frame with initial text
        textBox.AddTextFrame("Initial Text");

        // Access the text frame and modify the text
        Aspose.Slides.ITextFrame textFrame = textBox.TextFrame;
        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
        Aspose.Slides.IPortion portion = paragraph.Portions[0];
        portion.Text = "Aspose.Slides TextBox Example";

        // Retrieve all text boxes on the slide using SlideUtil
        Aspose.Slides.ITextFrame[] textBoxes = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);
        Console.WriteLine("Number of text boxes on the slide: " + textBoxes.Length);

        // Save the presentation
        presentation.Save("ManagedTextBoxes_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}