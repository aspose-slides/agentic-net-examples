using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace BubbleChartExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a bubble chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.Bubble, 50f, 50f, 600f, 400f);

                // Set bubble size representation to Width
                chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;

                // Access the chart's workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default categories and series
                chart.ChartData.Categories.Clear();
                chart.ChartData.Series.Clear();

                // Add categories (X values)
                IChartDataCell cellX1 = workbook.GetCell(0, "A1", "1");
                IChartDataCell cellX2 = workbook.GetCell(0, "A2", "2");
                IChartDataCell cellX3 = workbook.GetCell(0, "A3", "3");
                chart.ChartData.Categories.Add(cellX1);
                chart.ChartData.Categories.Add(cellX2);
                chart.ChartData.Categories.Add(cellX3);

                // Add a series for the bubble chart
                IChartSeries series = chart.ChartData.Series.Add(ChartType.Bubble);

                // Add Y values
                IChartDataCell cellY1 = workbook.GetCell(0, "B1", "10");
                IChartDataCell cellY2 = workbook.GetCell(0, "B2", "20");
                IChartDataCell cellY3 = workbook.GetCell(0, "B3", "30");

                // Add bubble size values (third column)
                IChartDataCell cellSize1 = workbook.GetCell(0, "C1", "5");
                IChartDataCell cellSize2 = workbook.GetCell(0, "C2", "15");
                IChartDataCell cellSize3 = workbook.GetCell(0, "C3", "25");

                // Add data points using X, Y, and bubble size cells
                series.DataPoints.AddDataPointForBubbleSeries(cellX1, cellY1, cellSize1);
                series.DataPoints.AddDataPointForBubbleSeries(cellX2, cellY2, cellSize2);
                series.DataPoints.AddDataPointForBubbleSeries(cellX3, cellY3, cellSize3);

                // Save the presentation
                string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "BubbleChart.pptx");
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}