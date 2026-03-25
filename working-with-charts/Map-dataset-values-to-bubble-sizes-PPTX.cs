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
            // Define output file path
            string outputPath = "BubbleChartOutput.pptx";

            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a bubble chart to the slide
                IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Bubble,
                    50f, 50f, 500f, 400f);

                // Access chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a new series
                IChartSeries series = chart.ChartData.Series.Add(
                    workbook.GetCell(0, 0, 1, "Series 1"),
                    chart.Type);

                // Set data source types to use literal double values for X, Y and bubble size
                series.DataPoints.DataSourceTypeForXValues = DataSourceType.DoubleLiterals;
                series.DataPoints.DataSourceTypeForYValues = DataSourceType.DoubleLiterals;
                series.DataPoints.DataSourceTypeForBubbleSizes = DataSourceType.DoubleLiterals;

                // Sample dataset: (X, Y, BubbleSize)
                double[,] data = new double[,]
                {
                    { 1.0, 2.0, 10.0 },
                    { 2.5, 3.5, 20.0 },
                    { 4.0, 1.5, 30.0 },
                    { 5.5, 4.0, 40.0 }
                };

                // Populate the series with data points
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    double x = data[i, 0];
                    double y = data[i, 1];
                    double size = data[i, 2];

                    series.DataPoints.AddDataPointForBubbleSeries(x, y, size);
                }

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }

            Console.WriteLine("Bubble chart created successfully at: " + Path.GetFullPath("BubbleChartOutput.pptx"));
        }
    }
}