using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "LineDashStyleDemo.pptx";
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.IAutoShape line = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);
            line.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.LargeDash;
            Aspose.Slides.ILineFormatEffectiveData effective = line.LineFormat.GetEffective();
            Console.WriteLine("DashStyle set to: " + effective.DashStyle);
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}