using System;
using System.Drawing;
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
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a bubble chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.Bubble, 50f, 50f, 500f, 400f);

            // Clear any default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add categories (X axis labels)
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category C"));

            // Add a bubble series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), ChartType.Bubble);

            // Populate the series with X, Y and bubble size values
            series.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(defaultWorksheetIndex, 1, 1, 10.0),   // X value
                workbook.GetCell(defaultWorksheetIndex, 1, 2, 20.0),   // Y value
                workbook.GetCell(defaultWorksheetIndex, 1, 3, 30.0));  // Bubble size

            series.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(defaultWorksheetIndex, 2, 1, 15.0),
                workbook.GetCell(defaultWorksheetIndex, 2, 2, 25.0),
                workbook.GetCell(defaultWorksheetIndex, 2, 3, 40.0));

            series.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(defaultWorksheetIndex, 3, 1, 20.0),
                workbook.GetCell(defaultWorksheetIndex, 3, 2, 30.0),
                workbook.GetCell(defaultWorksheetIndex, 3, 3, 50.0));

            // Enable automatic color variation for each bubble (maps colors to categories)
            series.ParentSeriesGroup.IsColorVaried = true;

            // Save the presentation
            try
            {
                pres.Save("BubbleChart.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // If the format is not supported, the Save method will throw an exception.
                // Comment: format not supported.
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}