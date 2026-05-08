using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a clustered column chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Calculate actual layout values for the chart elements
        chart.ValidateChartLayout();

        // Retrieve the actual X and Y positions of the plot area (in points)
        float actualX = chart.PlotArea.ActualX;
        float actualY = chart.PlotArea.ActualY;

        // The chart's width and height (as defined when adding the chart)
        float chartWidth = 500f;
        float chartHeight = 400f;

        // Adjust the plot area position manually using the retrieved actual values.
        // PlotArea.X and PlotArea.Y expect fractions of the chart's width/height.
        chart.PlotArea.AsILayoutable.X = actualX / chartWidth;
        chart.PlotArea.AsILayoutable.Y = actualY / chartHeight;

        // Optionally define how the plot area layout is calculated
        chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

        // Save the modified presentation
        presentation.Save("AdjustedPlotArea.pptx", SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}