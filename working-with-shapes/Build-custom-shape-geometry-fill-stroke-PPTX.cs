using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (var pres = new Aspose.Slides.Presentation())
            {
                var slide = pres.Slides[0];

                // Add a rectangle auto shape
                var autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

                // Cast to GeometryShape to define custom geometry
                var geometryShape = autoShape as Aspose.Slides.GeometryShape;

                // Create a custom geometry path (trapezoid example)
                var path = new Aspose.Slides.GeometryPath();
                path.MoveTo(0, 0);
                path.LineTo(geometryShape.Width, 0);
                path.LineTo(geometryShape.Width * 0.8f, geometryShape.Height);
                path.LineTo(geometryShape.Width * 0.2f, geometryShape.Height);
                path.CloseFigure();

                geometryShape.SetGeometryPath(path);

                // Apply solid fill
                geometryShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                geometryShape.FillFormat.SolidFillColor.Color = Color.LightBlue;

                // Configure stroke (line) properties
                geometryShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                geometryShape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
                geometryShape.LineFormat.Width = 2;

                // Save the presentation
                pres.Save("CustomShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}