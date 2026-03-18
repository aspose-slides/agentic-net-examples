using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ScatterChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (Presentation pres = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Add a scatter chart without sample data
                    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 50f, 50f, 400f, 300f, false);

                    // Remove any default series and categories
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Get the chart data workbook
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                    int defaultWorksheetIndex = 0;

                    // Add two series
                    IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), ChartType.ScatterWithMarkers);
                    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), ChartType.ScatterWithMarkers);

                    // Populate series1 with data points
                    series1.DataPoints.AddDataPointForScatterSeries(1.0, workbook.GetCell(defaultWorksheetIndex, 1, 1, 2.0));
                    series1.DataPoints.AddDataPointForScatterSeries(2.0, workbook.GetCell(defaultWorksheetIndex, 2, 1, 4.0));

                    // Populate series2 with data points
                    series2.DataPoints.AddDataPointForScatterSeries(1.5, workbook.GetCell(defaultWorksheetIndex, 1, 2, 3.0));
                    series2.DataPoints.AddDataPointForScatterSeries(2.5, workbook.GetCell(defaultWorksheetIndex, 2, 2, 5.0));

                    // Set chart title
                    chart.HasTitle = true;
                    chart.ChartTitle.AddTextFrameForOverriding("Scatter Chart Example");
                    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;

                    // Save the presentation
                    pres.Save("ScatterChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}