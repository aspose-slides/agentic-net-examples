using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace CustomCalloutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a line chart to the slide
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Line,
                    50f, 50f, 500f, 400f);

                // Access the chart's workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear any default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add categories (X-axis)
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Jan"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Feb"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Mar"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "Apr"));

                // Add a series (Y-axis)
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                    workbook.GetCell(0, 0, 1, "Sales"),
                    chart.Type);

                // Add data points to the series
                series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 150.0));
                series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 200.0));
                series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, 350.0)); // Target point
                series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, 300.0));

                // Get the specific data point to annotate (third point)
                Aspose.Slides.Charts.IChartDataPoint targetPoint = series.DataPoints[2];

                // Enable callout for the data label
                targetPoint.Label.DataLabelFormat.ShowLabelAsDataCallout = true;
                targetPoint.Label.DataLabelFormat.ShowLeaderLines = true;
                targetPoint.Label.DataLabelFormat.ShowValue = true;

                // Set custom text for the callout
                targetPoint.Label.AddTextFrameForOverriding("Peak Sales");

                // Format the callout text (bold)
                targetPoint.Label.TextFormat.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;

                // Save the presentation
                presentation.Save("CustomCalloutLineChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (System.NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, Aspose errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}