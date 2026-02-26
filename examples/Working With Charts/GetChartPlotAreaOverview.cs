using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartPlotAreaOverview
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string outputPath = "ChartPlotAreaOverview.pptx";

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a clustered column chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(
                ChartType.ClusteredColumn,
                50f,   // X position
                50f,   // Y position
                500f,  // Width
                350f   // Height
            );

            // Validate layout to obtain actual plot area values
            chart.ValidateChartLayout();

            // Retrieve actual plot area dimensions
            double actualX = chart.PlotArea.ActualX;
            double actualY = chart.PlotArea.ActualY;
            double actualWidth = chart.PlotArea.ActualWidth;
            double actualHeight = chart.PlotArea.ActualHeight;

            // Example usage of the obtained values (optional)
            Console.WriteLine($"Plot Area - X: {actualX}, Y: {actualY}, Width: {actualWidth}, Height: {actualHeight}");

            // Set layout target type correctly (use Inner instead of non‑existent Inside)
            chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}