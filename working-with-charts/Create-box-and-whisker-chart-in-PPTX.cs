using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Get the first slide
        ISlide slide = pres.Slides[0];

        // Add a BoxAndWhisker chart
        IChart chart = slide.Shapes.AddChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);

        // Access the chart data workbook
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Remove the default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add a new series
        IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), ChartType.BoxAndWhisker);

        // Add categories (optional for BoxAndWhisker)
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

        // Add data points for each category (values are comma‑separated)
        series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, 1, 1, "10,20,30,40,50"));
        series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, 2, 1, "15,25,35,45,55"));
        series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, 3, 1, "12,22,32,42,52"));

        // Set the quartile method (Tukey is not available; use Exclusive)
        series.QuartileMethod = QuartileMethodType.Exclusive;

        // Add a title to the chart
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("Box and Whisker Chart");

        // Save the presentation
        pres.Save("BoxAndWhiskerChart_out.pptx", SaveFormat.Pptx);
    }
}