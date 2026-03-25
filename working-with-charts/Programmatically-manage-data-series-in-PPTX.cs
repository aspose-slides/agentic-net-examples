using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartSeriesManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            try
            {
                // Load the existing presentation
                Presentation pres = new Presentation(inputPath);

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a new clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 400f, 300f);

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Get the chart data workbook for creating cells
                IChartDataWorkbook chartDataWorkbook = chart.ChartData.ChartDataWorkbook;

                // Add categories
                chart.ChartData.Categories.Add(chartDataWorkbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(chartDataWorkbook.GetCell(0, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(chartDataWorkbook.GetCell(0, 3, 0, "Category 3"));

                // Add first series
                IChartSeries series1 = chart.ChartData.Series.Add(chartDataWorkbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
                // Populate data points for first series
                series1.DataPoints.AddDataPointForBarSeries(chartDataWorkbook.GetCell(0, 1, 1, 20));
                series1.DataPoints.AddDataPointForBarSeries(chartDataWorkbook.GetCell(0, 2, 1, 50));
                series1.DataPoints.AddDataPointForBarSeries(chartDataWorkbook.GetCell(0, 3, 1, 30));

                // Add second series
                IChartSeries series2 = chart.ChartData.Series.Add(chartDataWorkbook.GetCell(0, 0, 2, "Series 2"), chart.Type);
                // Populate data points for second series
                series2.DataPoints.AddDataPointForBarSeries(chartDataWorkbook.GetCell(0, 1, 2, 30));
                series2.DataPoints.AddDataPointForBarSeries(chartDataWorkbook.GetCell(0, 2, 2, 10));
                series2.DataPoints.AddDataPointForBarSeries(chartDataWorkbook.GetCell(0, 3, 2, 60));

                // Update a data point value in the first series (e.g., change first point to 45)
                series1.DataPoints[0].Value.Data = 45;

                // Remove the second series from the chart
                chart.ChartData.Series.RemoveAt(1);

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}