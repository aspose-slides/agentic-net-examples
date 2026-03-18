using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartCalloutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a clustered column chart
                    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                    // Enable callout for all data labels in the first series
                    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

                    // Get the chart data worksheet
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                    // Clear default series and categories
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
                    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
                    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

                    // Style the first data point's callout (fill and line)
                    IChartDataPoint firstPoint = series.DataPoints[0];
                    firstPoint.Format.Fill.FillType = FillType.Solid;
                    firstPoint.Format.Fill.SolidFillColor.Color = Color.Red;
                    firstPoint.Format.Line.FillFormat.FillType = FillType.Solid;
                    firstPoint.Format.Line.FillFormat.SolidFillColor.Color = Color.Black;

                    // Save the presentation
                    presentation.Save("ChartCalloutOutput.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}