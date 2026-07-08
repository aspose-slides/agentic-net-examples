using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            // Add a line shape
            var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 100, 100, 400, 0);
            var line = (Aspose.Slides.IAutoShape)shape;
            // Set dash style to LargeDash (long dash)
            line.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.LargeDash;
            // Verify visual appearance by checking effective dash style
            var effective = line.LineFormat.GetEffective();
            Console.WriteLine("Effective DashStyle: " + effective.DashStyle);
            // Save presentation
            var outputPath = "LineDashStyleDemo.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}