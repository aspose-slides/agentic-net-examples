using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a clustered column chart to the first slide
                Chart chart = (Chart)presentation.Slides[0].Shapes.AddChart(
                    ChartType.ClusteredColumn, 50f, 50f, 600f, 400f);

                // Get formatted plot area dimensions
                string dimensions = GetPlotAreaDimensions(chart);
                Console.WriteLine(dimensions);

                // Save the presentation
                string outputPath = "OutputPresentation.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Returns a formatted string with the plot area dimensions of the given chart
        static string GetPlotAreaDimensions(IChart chart)
        {
            // Ensure layout is calculated
            chart.ValidateChartLayout();

            double x = chart.PlotArea.ActualX;
            double y = chart.PlotArea.ActualY;
            double width = chart.PlotArea.ActualWidth;
            double height = chart.PlotArea.ActualHeight;

            return $"Plot Area - X: {x}, Y: {y}, Width: {width}, Height: {height}";
        }
    }
}