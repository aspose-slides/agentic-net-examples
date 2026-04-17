using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddMultilineCalloutToBubbleChart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a bubble chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 500, 400);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add a series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                chart.Type);

            // Add data points for the bubble series (X, Y, BubbleSize)
            series.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(defaultWorksheetIndex, 1, 1, 10),   // X value
                workbook.GetCell(defaultWorksheetIndex, 1, 2, 20),   // Y value
                workbook.GetCell(defaultWorksheetIndex, 1, 3, 30)); // Bubble size

            series.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(defaultWorksheetIndex, 2, 1, 15),
                workbook.GetCell(defaultWorksheetIndex, 2, 2, 25),
                workbook.GetCell(defaultWorksheetIndex, 2, 3, 35));

            // Enable callouts for data labels in this series
            series.Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

            // Annotate the first bubble with a multiline callout
            Aspose.Slides.Charts.IChartDataPoint firstPoint = series.DataPoints[0];
            Aspose.Slides.Charts.IDataLabel dataLabel = firstPoint.Label;
            // Set multiline text (use line break)
            dataLabel.TextFrameForOverriding.Text = "First Bubble\r\nImportant Note";

            // Save the presentation
            try
            {
                pres.Save("BubbleChartWithMultilineCallout.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions such as unsupported format
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}