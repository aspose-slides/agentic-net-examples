using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "LineDashStyleDemo.pptx";
        try
        {
            Presentation presentation = new Presentation();
            ISlide slide = presentation.Slides[0];
            // Add a plain line shape
            IAutoShape line = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 100, 300, 0);
            // Set dash style to LargeDash (long dash)
            line.LineFormat.DashStyle = LineDashStyle.LargeDash;
            // Verify visual appearance by outputting the effective dash style
            LineDashStyle effectiveDash = line.LineFormat.GetEffective().DashStyle;
            Console.WriteLine("Effective DashStyle: " + effectiveDash);
            // Save presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}