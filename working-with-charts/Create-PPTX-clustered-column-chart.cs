using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50, 50, 500, 400);

            // Set chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Clustered Column Chart");

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add series
            chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                chart.Type);
            chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"),
                chart.Type);

            // Add categories
            chart.ChartData.Categories.Add(
                workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(
                workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(
                workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Populate first series data points
            IChartSeries series1 = chart.ChartData.Series[0];
            series1.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
            series1.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
            series1.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));
            series1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            series1.Format.Fill.SolidFillColor.Color = Color.Red;

            // Populate second series data points
            IChartSeries series2 = chart.ChartData.Series[1];
            series2.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
            series2.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
            series2.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));
            series2.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            series2.Format.Fill.SolidFillColor.Color = Color.Green;

            // Save the presentation
            presentation.Save("ClusteredColumnChart.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}