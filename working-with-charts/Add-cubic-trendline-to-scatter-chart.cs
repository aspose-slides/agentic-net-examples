using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a scatter chart with smooth lines
            IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0f, 0f, 400f, 400f);

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add two series
            chart.ChartData.Series.Add(workbook.GetCell(0, 1, 1, "Series 1"), chart.Type);
            chart.ChartData.Series.Add(workbook.GetCell(0, 1, 3, "Series 2"), chart.Type);

            // Populate data for the first series
            IChartSeries series1 = chart.ChartData.Series[0];
            series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(0, 2, 1, 1.0), workbook.GetCell(0, 2, 2, 2.0));
            series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(0, 3, 1, 2.0), workbook.GetCell(0, 3, 2, 3.0));

            // Add a polynomial trend line of order 3 to the first series
            ITrendline trendline = series1.TrendLines.Add(TrendlineType.Polynomial);
            trendline.Order = 3;

            // Save the presentation
            string outputPath = "ScatterChartWithTrendline.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}