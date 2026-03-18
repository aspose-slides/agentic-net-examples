using System;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
            shape.LineFormat.Style = Aspose.Slides.LineStyle.ThickThin;
            shape.LineFormat.Width = 5;
            shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            presentation.Save("RectangleLineStyle.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}