using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ManageChartDataMarkers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input PPTX path as first argument, output path as second (optional)
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the input presentation file path as the first argument.");
                return;
            }

            string inputPath = args[0];
            string outputPath = args.Length > 1 ? args[1] : "ManagedDataMarkers_out.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Error: The file \"{inputPath}\" was not found.");
                return;
            }

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart with no sample data (initWithSample = false)
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400, false);

                // Access the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear any default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a new series
                IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));

                // Populate series with data points
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 40));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

                // ---- Manage Data Markers ----

                // Set marker style and size for the entire series
                IMarker seriesMarker = series.Marker;
                seriesMarker.Symbol = MarkerStyleType.Circle;
                seriesMarker.Size = 12;

                // Change marker for the second data point only
                IChartDataPoint secondPoint = series.DataPoints[1];
                IMarker pointMarker = secondPoint.Marker;
                pointMarker.Symbol = MarkerStyleType.Square;
                pointMarker.Size = 16;

                // Remove the third data point from the series
                IChartDataPoint thirdPoint = series.DataPoints[2];
                thirdPoint.Remove();

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine($"Presentation saved to \"{outputPath}\".");
            }
        }
    }
}