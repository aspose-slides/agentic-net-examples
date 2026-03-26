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
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a bubble chart without sample data
                IChart chart = slide.Shapes.AddChart(ChartType.Bubble, 50f, 50f, 500f, 400f, false);

                // Access the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear any default series and categories (if any)
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a new bubble series
                IChartSeries series = chart.ChartData.Series.Add(
                    workbook.GetCell(0, 0, 1, "Series 1"),
                    ChartType.Bubble);

                // Configure data source types to use double literals for X, Y, values and bubble sizes
                series.DataPoints.DataSourceTypeForXValues = DataSourceType.DoubleLiterals;
                series.DataPoints.DataSourceTypeForYValues = DataSourceType.DoubleLiterals;
                series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;
                series.DataPoints.DataSourceTypeForBubbleSizes = DataSourceType.DoubleLiterals;

                // Add bubble data points (x, y, size) using double literals
                series.DataPoints.AddDataPointForBubbleSeries(1.0, 2.0, 3.0);
                series.DataPoints.AddDataPointForBubbleSeries(2.5, 3.5, 4.5);
                series.DataPoints.AddDataPointForBubbleSeries(4.0, 1.5, 2.0);

                // Save the presentation
                string outputPath = "BubbleChartOutput.pptx";
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}