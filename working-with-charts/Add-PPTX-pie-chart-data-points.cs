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
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a pie chart without sample data
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400, false);

            // Remove default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            int defaultWorksheetIndex = 0;
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add a series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                ChartType.Pie);

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category C"));

            // Add data points to the series
            series.DataPoints.AddDataPointForPieSeries(30);
            series.DataPoints.AddDataPointForPieSeries(50);
            series.DataPoints.AddDataPointForPieSeries(20);

            // Save the presentation
            pres.Save("PieChartDataPoints.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}