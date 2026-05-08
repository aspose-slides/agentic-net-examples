using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Presentation presentation = new Presentation();
            ISlide slide = presentation.Slides[0];
            IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 500, 500);
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Clear default data
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add series
            chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
            chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

            // Add categories (optional for scatter)
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));

            // Populate first series with data points
            IChartSeries series0 = chart.ChartData.Series[0];
            series0.DataPoints.AddDataPointForScatterSeries(1.0, 2.0);
            series0.DataPoints.AddDataPointForScatterSeries(2.0, 3.5);

            // Add linear trendline and set forward/backward lengths
            ITrendline trendline = series0.TrendLines.Add(TrendlineType.Linear);
            trendline.Forward = 0;
            trendline.Backward = 3;

            // Save presentation
            string outputPath = "ScatterTrendline.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}