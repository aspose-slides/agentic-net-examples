using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 75, 150, 50);
            shape.AddTextFrame(" ");
            var textFrame = shape.TextFrame;
            var paragraph = textFrame.Paragraphs[0];
            var portion = paragraph.Portions[0];
            portion.Text = "Aspose TextBox";
            presentation.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}