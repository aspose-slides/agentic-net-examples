using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DoughnutChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a doughnut chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Doughnut, 50f, 50f, 500f, 400f);

            // Access the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Remove default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));

            // Add a series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

            // Add data points for the doughnut series
            series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(0, 1, 1, 30.0));
            series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(0, 2, 1, 50.0));
            series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(0, 3, 1, 20.0));

            // Set the doughnut hole size (e.g., 50%)
            series.ParentSeriesGroup.DoughnutHoleSize = (byte)50;

            // Save the presentation
            pres.Save("DoughnutChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}