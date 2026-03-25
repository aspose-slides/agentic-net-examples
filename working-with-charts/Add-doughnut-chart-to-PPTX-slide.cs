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

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a doughnut chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Doughnut, 50f, 50f, 500f, 400f);

        // Set doughnut hole size to 50%
        chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = (byte)50;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add categories
        Aspose.Slides.Charts.IChartCategory category1 = chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
        Aspose.Slides.Charts.IChartCategory category2 = chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
        Aspose.Slides.Charts.IChartCategory category3 = chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));

        // Add a series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

        // Add data points for doughnut series
        series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(0, 1, 1, 30.0));
        series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(0, 2, 1, 50.0));
        series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(0, 3, 1, 20.0));

        // Save the presentation
        pres.Save("DoughnutChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}