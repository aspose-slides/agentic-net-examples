using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle auto shape to serve as the base for a custom line shape
        Aspose.Slides.GeometryShape shape = (Aspose.Slides.GeometryShape)presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

        // Retrieve the first geometry path of the shape
        Aspose.Slides.IGeometryPath geometryPath = shape.GetGeometryPaths()[0];

        // Define custom geometry (a simple V shape)
        geometryPath.MoveTo(0, 0);
        geometryPath.LineTo(shape.Width, shape.Height);
        geometryPath.LineTo(shape.Width, 0);
        geometryPath.CloseFigure();

        // Apply the custom geometry to the shape
        shape.SetGeometryPath(geometryPath);

        // Format the line of the custom shape
        shape.LineFormat.Style = Aspose.Slides.LineStyle.ThickThin;
        shape.LineFormat.Width = 5;
        shape.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dash;
        shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;

        // Save the presentation
        string outputPath = "CustomLine.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}