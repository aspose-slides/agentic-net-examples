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
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];

            // Add a rectangle shape and cast to GeometryShape for custom geometry
            var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 200) as Aspose.Slides.GeometryShape;

            // Define a custom geometry path (simple quadrilateral)
            var geometryPath = new Aspose.Slides.GeometryPath();
            geometryPath.MoveTo(0, 0);
            geometryPath.LineTo(shape.Width, 0);
            geometryPath.LineTo(shape.Width, shape.Height);
            geometryPath.LineTo(0, shape.Height);
            geometryPath.CloseFigure();

            // Apply the custom geometry to the shape
            shape.SetGeometryPath(geometryPath);

            // Styling: solid fill and line
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
            shape.LineFormat.Width = 2;
            shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;

            // Save the presentation
            presentation.Save("CustomShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}