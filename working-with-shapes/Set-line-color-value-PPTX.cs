using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Presentation();
            var slide = presentation.Slides[0];
            var lineShape = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 50, 300, 0);
            // Set line to solid fill and assign a specific color
            lineShape.LineFormat.FillFormat.FillType = FillType.Solid;
            lineShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            // Save the presentation
            presentation.Save("LineColorExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}