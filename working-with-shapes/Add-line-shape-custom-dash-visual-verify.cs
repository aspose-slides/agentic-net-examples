using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var pres = new Aspose.Slides.Presentation();

        // Get the first slide
        var slide = pres.Slides[0];

        // Add a line shape to the slide
        var line = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 100, 100, 400, 0);

        // Set line width
        line.LineFormat.Width = 5;

        // Set custom dash style and pattern
        line.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Custom;
        line.LineFormat.CustomDashPattern = new float[] { 5, 2, 1, 2 }; // dash, gap, dash, gap

        // Set line color
        line.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

        // Save the presentation
        var outputPath = "CustomDashLine.pptx";
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}