using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line shape to the slide
        Aspose.Slides.IAutoShape line = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 100, 100, 400, 0);

        // Set basic line properties
        line.LineFormat.Style = Aspose.Slides.LineStyle.Single;
        line.LineFormat.Width = 5;

        // Apply a custom dash pattern
        line.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Custom;
        line.LineFormat.CustomDashPattern = new float[] { 5, 2, 1, 2 }; // dash, gap, dash, gap

        // Verify the applied dash style and pattern
        Aspose.Slides.ILineFormatEffectiveData effective = line.LineFormat.GetEffective();
        Console.WriteLine("DashStyle: " + effective.DashStyle);
        Console.WriteLine("CustomDashPattern: " + string.Join(",", effective.CustomDashPattern));

        // Save the presentation
        string outputPath = "CustomDashLine.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}