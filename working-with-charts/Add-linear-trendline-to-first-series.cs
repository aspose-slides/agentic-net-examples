using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace TrendLineExample
{
    class Program
    {
        static void Main()
        {
            // Output file path
            var outputPath = "TrendLineChart.pptx";

            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Add a clustered column chart to the first slide
            var chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // Add a linear trend line to the first data series
            var trendLine = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Linear);
            trendLine.DisplayEquation = false;
            trendLine.DisplayRSquaredValue = false;

            // Save the presentation
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other save errors
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}