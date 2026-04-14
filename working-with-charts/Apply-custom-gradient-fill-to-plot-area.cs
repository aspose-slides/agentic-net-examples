using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Apply a custom gradient fill to the chart's plot area
        Aspose.Slides.IFillFormat plotFill = chart.PlotArea.Format.Fill;
        plotFill.FillType = Aspose.Slides.FillType.Gradient;
        plotFill.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
        plotFill.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;
        plotFill.GradientFormat.GradientStops.Add(0, Aspose.Slides.PresetColor.Purple);
        plotFill.GradientFormat.GradientStops.Add(1, Aspose.Slides.PresetColor.Red);

        // Save the presentation
        string outputPath = "ChartWithGradient.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}