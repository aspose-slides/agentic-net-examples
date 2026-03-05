using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line shape to the slide
        Aspose.Slides.IAutoShape line = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

        // Customize the line's formatting
        line.LineFormat.Style = Aspose.Slides.LineStyle.ThickBetweenThin;
        line.LineFormat.Width = 10;
        line.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.DashDot;
        line.LineFormat.BeginArrowheadLength = Aspose.Slides.LineArrowheadLength.Short;
        line.LineFormat.BeginArrowheadStyle = Aspose.Slides.LineArrowheadStyle.Oval;
        line.LineFormat.EndArrowheadLength = Aspose.Slides.LineArrowheadLength.Long;
        line.LineFormat.EndArrowheadStyle = Aspose.Slides.LineArrowheadStyle.Triangle;
        line.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        line.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

        // Example of customizing geometry of another shape
        Aspose.Slides.GeometryShape geometryShape = (Aspose.Slides.GeometryShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 200, 200, 100);
        Aspose.Slides.IGeometryPath geometryPath = geometryShape.GetGeometryPaths()[0];
        geometryPath.LineTo(200, 0, 1);
        geometryPath.LineTo(0, 100, 2);
        geometryShape.SetGeometryPath(geometryPath);

        // Save the presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}