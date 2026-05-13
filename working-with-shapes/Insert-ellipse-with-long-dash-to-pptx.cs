using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        var slide = presentation.Slides[0];

        // Add an ellipse shape
        var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 300, 150);

        // Set line dash style to large dash
        shape.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.LargeDash;

        // Save the presentation
        var outputPath = "EllipseLongDash.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}