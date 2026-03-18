using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];

            // Add a rectangle shape
            var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = Color.LightBlue;

            // Apply reflection effect
            shape.EffectFormat.EnableReflectionEffect();

            // Save the presentation
            presentation.Save("ReflectionExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}