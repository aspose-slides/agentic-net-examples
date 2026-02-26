using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

namespace TrendlineStyleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a clustered column chart on the first slide
            IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Add sample data to the chart (required for a series to exist)
            IChartData chartData = chart.ChartData;
            chartData.Series.Clear();
            chartData.Categories.Clear();

            // Add categories
            chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A1", "Category 1"));
            chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2", "Category 2"));
            chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3", "Category 3"));

            // Add a series and populate it with values
            IChartSeries series = chartData.Series.Add(chartData.ChartDataWorkbook.GetCell(0, "B1", "Series 1"),
                                                         chart.Type);
            series.DataPoints.AddDataPointForBarSeries(chartData.ChartDataWorkbook.GetCell(0, "B1", 10));
            series.DataPoints.AddDataPointForBarSeries(chartData.ChartDataWorkbook.GetCell(0, "B2", 20));
            series.DataPoints.AddDataPointForBarSeries(chartData.ChartDataWorkbook.GetCell(0, "B3", 30));

            // Add a linear trendline to the series
            ITrendline trendline = series.TrendLines.Add(TrendlineType.Linear);

            // Customize the trendline style: set line color to red and width to 5 points
            trendline.Format.Line.FillFormat.FillType = FillType.Solid;
            trendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
            trendline.Format.Line.Width = 5.0;

            // Save the presentation
            pres.Save("TrendlineStyle.pptx", SaveFormat.Pptx);
        }
    }
}