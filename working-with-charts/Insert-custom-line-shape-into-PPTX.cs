using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a rectangle auto shape and cast it to GeometryShape for custom geometry
        Aspose.Slides.GeometryShape shape = (Aspose.Slides.GeometryShape)presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

        // Define a custom geometry path (a simple rectangle here, can be modified to a line shape)
        Aspose.Slides.GeometryPath geometryPath = new Aspose.Slides.GeometryPath();
        geometryPath.MoveTo(0, 0);
        geometryPath.LineTo(shape.Width, 0);
        geometryPath.LineTo(shape.Width, shape.Height);
        geometryPath.LineTo(0, shape.Height);
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