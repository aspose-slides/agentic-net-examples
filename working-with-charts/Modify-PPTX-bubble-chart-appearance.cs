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
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a bubble chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 500, 400);

            // Access the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Remove default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add categories (X axis labels)
            int defaultWorksheetIndex = 0;
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Add a bubble series
            IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), ChartType.Bubble);

            // Use literal values for bubble sizes
            series.DataPoints.DataSourceTypeForBubbleSizes = DataSourceType.DoubleLiterals;

            // Add bubble data points (X value, Y value, Bubble size)
            series.DataPoints.AddDataPointForBubbleSeries(1.0, 4.0, 30.0);
            series.DataPoints.AddDataPointForBubbleSeries(2.0, 5.0, 40.0);
            series.DataPoints.AddDataPointForBubbleSeries(3.0, 2.0, 20.0);

            // Set number format for bubble sizes
            series.NumberFormatOfBubbleSizes = "#,##0";

            // Show bubble size values in data labels
            series.Labels.DefaultDataLabelFormat.ShowBubbleSize = true;

            // Enable 3‑D effect for the first bubble
            series.DataPoints[0].IsBubble3D = true;

            // Set fill color for the series
            series.Format.Fill.FillType = FillType.Solid;
            series.Format.Fill.SolidFillColor.Color = Color.CornflowerBlue;

            // Save the presentation
            presentation.Save("ModifiedBubbleChart.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}