using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
            shape.TextFrame.Text = "5 + 3 =";

            var a = 5;
            var b = 3;
            var result = a + b;

            var paragraph = shape.TextFrame.Paragraphs[0];
            var portion = paragraph.Portions[0];
            portion.Text = $"5 + 3 = {result}";

            presentation.Save("ArithmeticPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}