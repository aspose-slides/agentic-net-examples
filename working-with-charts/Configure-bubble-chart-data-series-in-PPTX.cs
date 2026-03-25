using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace BubbleChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "BubbleChart.pptx";

            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Add a bubble chart to the first slide
                IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50f, 50f, 600f, 400f);

                // Access the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add series
                chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
                chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

                // Add categories (optional for bubble chart)
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                // Populate first series with bubble data points
                IChartSeries series1 = chart.ChartData.Series[0];
                series1.DataPoints.AddDataPointForBubbleSeries(10.0, 20.0, 30.0);
                series1.DataPoints.AddDataPointForBubbleSeries(15.0, 25.0, 35.0);
                series1.DataPoints.AddDataPointForBubbleSeries(20.0, 30.0, 40.0);

                // Populate second series with bubble data points
                IChartSeries series2 = chart.ChartData.Series[1];
                series2.DataPoints.AddDataPointForBubbleSeries(12.0, 22.0, 32.0);
                series2.DataPoints.AddDataPointForBubbleSeries(18.0, 28.0, 38.0);
                series2.DataPoints.AddDataPointForBubbleSeries(24.0, 34.0, 44.0);

                // Configure bubble chart scaling and size representation
                chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150; // 150% of default size
                chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (FileNotFoundException fnfEx)
            {
                Console.WriteLine("File not found: " + fnfEx.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}