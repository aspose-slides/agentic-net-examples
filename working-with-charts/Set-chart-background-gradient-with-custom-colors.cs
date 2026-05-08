using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);
            // Set chart background fill to a gradient with custom colors
            chart.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
            chart.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
            chart.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;
            chart.FillFormat.GradientFormat.GradientStops.Add(0, System.Drawing.Color.FromArgb(255, 0, 128, 255)); // custom blue
            chart.FillFormat.GradientFormat.GradientStops.Add(1, System.Drawing.Color.FromArgb(255, 255, 128, 0)); // custom orange
            var outputPath = "ChartGradientBackground.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
        }
    }
}