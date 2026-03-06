using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Get the first slide
        ISlide slide = pres.Slides[0];

        // Add a doughnut chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.Doughnut, 50, 50, 500, 400);

        // Remove default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Access the chart data workbook
        int defaultWorksheetIndex = 0;
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));

        // Add series
        IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
        IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

        // Populate series with data points
        series1.DataPoints.AddDataPointForDoughnutSeries(30);
        series1.DataPoints.AddDataPointForDoughnutSeries(70);
        series2.DataPoints.AddDataPointForDoughnutSeries(40);
        series2.DataPoints.AddDataPointForDoughnutSeries(60);

        // Set the center gap (hole size) of the doughnut chart to 50%
        IChartSeriesGroup group = series1.ParentSeriesGroup;
        group.DoughnutHoleSize = 50;

        // Save the presentation
        pres.Save("DoughnutChartCenterGap.pptx", SaveFormat.Pptx);
    }
}