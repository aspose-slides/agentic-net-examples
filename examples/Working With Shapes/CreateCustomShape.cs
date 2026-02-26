using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CustomShapeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a rectangle auto shape to the first slide
            Aspose.Slides.IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100f, 100f, 200f, 100f);

            // Cast the auto shape to GeometryShape to allow custom geometry
            Aspose.Slides.GeometryShape geometryShape = autoShape as Aspose.Slides.GeometryShape;

            // Define a custom geometry path (simple rectangle matching the shape bounds)
            Aspose.Slides.GeometryPath customPath = new Aspose.Slides.GeometryPath();
            customPath.MoveTo(0f, 0f);
            customPath.LineTo(geometryShape.Width, 0f);
            customPath.LineTo(geometryShape.Width, geometryShape.Height);
            customPath.LineTo(0f, geometryShape.Height);
            customPath.CloseFigure();

            // Apply the custom geometry to the shape
            geometryShape.SetGeometryPath(customPath);

            // Set solid fill color for the shape
            geometryShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            geometryShape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

            // Set line (stroke) formatting
            geometryShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            geometryShape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
            geometryShape.LineFormat.Width = 2f;

            // Save the presentation
            presentation.Save("CustomShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}