using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
            shape.LineFormat.Width = 5;
            shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

            var effectiveLine = shape.LineFormat.GetEffective();

            Console.WriteLine("Style: " + effectiveLine.Style);
            Console.WriteLine("Width: " + effectiveLine.Width);
            Console.WriteLine("Fill type: " + effectiveLine.FillFormat.FillType);

            presentation.Save("EffectiveLineFormat.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}