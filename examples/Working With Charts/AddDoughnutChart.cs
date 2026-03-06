using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a doughnut chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.Doughnut, 50, 50, 500, 400);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the default worksheet
            int defaultWorksheetIndex = 0;
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add a series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category C"));

            // Add data points for the doughnut series
            series.DataPoints.AddDataPointForDoughnutSeries(30);
            series.DataPoints.AddDataPointForDoughnutSeries(20);
            series.DataPoints.AddDataPointForDoughnutSeries(50);

            // Set the doughnut hole size (percentage of plot area)
            series.ParentSeriesGroup.DoughnutHoleSize = 50; // 50%

            // Save the presentation
            presentation.Save("DoughnutChart_out.pptx", SaveFormat.Pptx);
        }
    }
}