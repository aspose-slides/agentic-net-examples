using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Access chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add a series
            IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), ChartType.ClusteredColumn);

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));

            // Add data points
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 40));

            // Set series fill type to solid to enable inverted fill
            series.Format.Fill.FillType = Aspose.Slides.FillType.Solid;

            // Set inverted solid fill color
            series.InvertedSolidFillColor.Color = Color.Blue;

            // Save the presentation
            pres.Save("InvertedFillChart.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}