using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace BubbleChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a bubble chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50f, 50f, 600f, 400f);

            // Set bubble size representation to Width
            chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;

            // Optionally set bubble size scaling (e.g., 150%)
            chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

            // Access the chart's workbook to add data
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear any default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add a series for bubble data
            IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

            // Add data points (X, Y, Size) and assign colors
            IChartDataPoint point1 = series.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(0, 1, 1, 10),   // X value
                workbook.GetCell(0, 1, 2, 20),   // Y value
                workbook.GetCell(0, 1, 3, 30));  // Bubble size
            point1.Format.Fill.FillType = FillType.Solid;
            point1.Format.Fill.SolidFillColor.Color = Color.Red;

            IChartDataPoint point2 = series.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(0, 2, 1, 15),
                workbook.GetCell(0, 2, 2, 25),
                workbook.GetCell(0, 2, 3, 40));
            point2.Format.Fill.FillType = FillType.Solid;
            point2.Format.Fill.SolidFillColor.Color = Color.Green;

            IChartDataPoint point3 = series.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(0, 3, 1, 20),
                workbook.GetCell(0, 3, 2, 30),
                workbook.GetCell(0, 3, 3, 50));
            point3.Format.Fill.FillType = FillType.Solid;
            point3.Format.Fill.SolidFillColor.Color = Color.Blue;

            // Save the presentation
            string outputPath = "BubbleChartWithColors.pptx";
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex) when (ex is NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
            }
        }
    }
}