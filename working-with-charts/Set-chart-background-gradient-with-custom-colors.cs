using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Set chart background fill to a gradient
            chart.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
            chart.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
            chart.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;

            // Add gradient stops with custom colors
            chart.FillFormat.GradientFormat.GradientStops.Add(0.0f, Color.FromArgb(255, 0, 0)); // Red at start
            chart.FillFormat.GradientFormat.GradientStops.Add(1.0f, Color.FromArgb(0, 0, 255)); // Blue at end

            presentation.Save("ChartGradientBackground.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}