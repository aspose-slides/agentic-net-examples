using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartPlotAreaDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a sample chart to the slide
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50, 50, 500, 400);

                // Get formatted plot area dimensions
                string dimensions = GetPlotAreaDimensions(chart);
                Console.WriteLine(dimensions);

                // Save the presentation
                presentation.Save("ChartPlotAreaDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }

        /// <summary>
        /// Returns a formatted string containing the actual dimensions of the chart's plot area.
        /// </summary>
        /// <param name="chart">The chart whose plot area is examined.</param>
        /// <returns>Formatted dimensions string.</returns>
        static string GetPlotAreaDimensions(Aspose.Slides.Charts.IChart chart)
        {
            // Ensure layout calculations are up to date
            chart.ValidateChartLayout();

            // Access the plot area
            Aspose.Slides.Charts.IChartPlotArea plotArea = chart.PlotArea;

            // Retrieve actual values
            float actualX = plotArea.ActualX;
            float actualY = plotArea.ActualY;
            float actualWidth = plotArea.ActualWidth;
            float actualHeight = plotArea.ActualHeight;

            // Format the dimensions string
            return string.Format(
                "Plot Area - X: {0:F2} pt, Y: {1:F2} pt, Width: {2:F2} pt, Height: {3:F2} pt",
                actualX, actualY, actualWidth, actualHeight);
        }
    }
}