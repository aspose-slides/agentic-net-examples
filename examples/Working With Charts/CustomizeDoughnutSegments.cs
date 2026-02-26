using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a doughnut chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.Doughnut, 50, 50, 500, 400);

        // Access the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Remove default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add categories
        int defaultWorksheetIndex = 0;
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

        // Add a series for the doughnut chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), ChartType.Doughnut);

        // Add data points to the series
        series.DataPoints.AddDataPointForDoughnutSeries(30);
        series.DataPoints.AddDataPointForDoughnutSeries(40);
        series.DataPoints.AddDataPointForDoughnutSeries(30);

        // Customize the doughnut hole size (read/write via parent series group)
        series.ParentSeriesGroup.DoughnutHoleSize = 50; // 50 percent

        // Set the angle of the first slice
        series.ParentSeriesGroup.FirstSliceAngle = 90; // start at 90 degrees

        // Explode the second segment
        Aspose.Slides.Charts.IChartDataPoint secondPoint = series.DataPoints[1];
        secondPoint.Explosion = 20; // 20 percent explosion

        // Save the presentation
        presentation.Save("CustomDoughnutChart_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}