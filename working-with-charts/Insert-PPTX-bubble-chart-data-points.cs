using System;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a bubble chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 500f, 400f);

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

            // Remove default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add a new series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                wb.GetCell(0, 0, 1, "Series 1"), Aspose.Slides.Charts.ChartType.Bubble);

            // Add categories (required for bubble chart)
            chart.ChartData.Categories.Add(wb.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(wb.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(wb.GetCell(0, 3, 0, "Category 3"));

            // Configure data source types to accept double literals
            series.DataPoints.DataSourceTypeForXValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
            series.DataPoints.DataSourceTypeForYValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
            series.DataPoints.DataSourceTypeForBubbleSizes = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

            // Add bubble data points (x, y, size)
            series.DataPoints.AddDataPointForBubbleSeries(1.0, 2.0, 3.0);
            series.DataPoints.AddDataPointForBubbleSeries(2.0, 4.0, 6.0);
            series.DataPoints.AddDataPointForBubbleSeries(3.0, 6.0, 9.0);

            // Save the presentation
            pres.Save("BubbleChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}