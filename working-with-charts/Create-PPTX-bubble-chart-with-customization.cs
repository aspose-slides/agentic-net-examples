using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace BubbleChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a bubble chart to the slide
                IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Bubble,
                    50f, 50f, 500f, 400f);

                // Remove default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Get the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Add a new series
                IChartSeries series = chart.ChartData.Series.Add(
                    workbook.GetCell(0, 0, 1, "Series 1"),
                    chart.Type);

                // Add bubble data points (X, Y, Size)
                series.DataPoints.AddDataPointForBubbleSeries(10.0, 20.0, 30.0);
                series.DataPoints.AddDataPointForBubbleSeries(15.0, 25.0, 35.0);
                series.DataPoints.AddDataPointForBubbleSeries(20.0, 30.0, 40.0);

                // Set chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Bubble Chart Example");

                // Save the presentation
                pres.Save("BubbleChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}