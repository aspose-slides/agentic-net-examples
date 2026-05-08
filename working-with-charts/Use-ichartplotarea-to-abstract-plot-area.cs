using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "ChartPlotAreaExample.pptx";

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20f, 100f, 600f, 400f);

        // Use IChartPlotArea to set layout properties
        IChartPlotArea plotArea = chart.PlotArea;
        plotArea.AsILayoutable.X = 0.1f;          // Fractional X position
        plotArea.AsILayoutable.Y = 0.1f;          // Fractional Y position
        plotArea.AsILayoutable.Width = 0.8f;      // Fractional width
        plotArea.AsILayoutable.Height = 0.8f;     // Fractional height
        plotArea.LayoutTargetType = LayoutTargetType.Inner; // Layout inside the chart area

        // Enable rounded corners and set line format (using support-for-chart-area-rounded-borders rule)
        chart.HasRoundedCorners = true;
        chart.LineFormat.FillFormat.FillType = FillType.Solid;
        chart.LineFormat.Style = LineStyle.Single;

        // Save the presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}