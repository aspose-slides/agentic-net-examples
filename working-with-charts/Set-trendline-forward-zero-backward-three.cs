using System;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a scatter chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines, 0f, 0f, 400f, 400f);

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add two series
            chart.ChartData.Series.Add(workbook.GetCell(0, 1, 1, "Series 1"), chart.Type);
            chart.ChartData.Series.Add(workbook.GetCell(0, 1, 3, "Series 2"), chart.Type);

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "Category 3"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 5, 0, "Category 4"));

            // Populate first series with scatter data points
            Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[0];
            series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(0, 2, 1, 1.0), workbook.GetCell(0, 2, 2, 3.0));
            series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(0, 3, 1, 2.0), workbook.GetCell(0, 3, 2, 5.0));
            series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(0, 4, 1, 3.0), workbook.GetCell(0, 4, 2, 7.0));
            series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(0, 5, 1, 4.0), workbook.GetCell(0, 5, 2, 9.0));

            // Add a linear trendline to the first series
            Aspose.Slides.Charts.ITrendline trendline = series1.TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Linear);
            trendline.Forward = 0.0;
            trendline.Backward = 3.0;

            // Save the presentation
            presentation.Save("ScatterTrendline.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}