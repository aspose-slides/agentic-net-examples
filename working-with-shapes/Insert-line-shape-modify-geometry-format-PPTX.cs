using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Presentation();
            var slide = presentation.Slides[0];
            var lineShape = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 100, 200, 0) as GeometryShape;
            if (lineShape != null)
            {
                var geometryPath = new GeometryPath();
                geometryPath.MoveTo(0, 0);
                geometryPath.LineTo(lineShape.Width, 0);
                lineShape.SetGeometryPath(geometryPath);

                var lineFormat = lineShape.LineFormat;
                lineFormat.Width = 5;
                lineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            }
            presentation.Save("ModifiedLine.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}