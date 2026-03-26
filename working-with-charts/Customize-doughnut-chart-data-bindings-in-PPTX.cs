using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a doughnut chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Doughnut, 50, 50, 500, 400);

        // Remove default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

        // Add a series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

        // Add data points for the doughnut series
        series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(0, 1, 1, 30));
        series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(0, 2, 1, 50));
        series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(0, 3, 1, 20));

        // Customize the doughnut hole size (percentage of plot area)
        series.ParentSeriesGroup.DoughnutHoleSize = 50; // 50%

        // Save the presentation
        pres.Save("CustomizedDoughnutChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}