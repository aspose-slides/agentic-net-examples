using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

namespace BubbleChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a bubble chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(
                ChartType.Bubble, 50f, 50f, 600f, 400f);

            // Set bubble size representation to Width
            chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;

            // Set bubble size scaling (e.g., 150%)
            chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

            // Enable varied colors for each bubble
            chart.ChartData.SeriesGroups[0].IsColorVaried = true;

            // Access the workbook to add data
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add first series (X, Y, Size)
            IChartSeries series = chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

            // Add data points for the bubble series
            // Point 1
            IChartDataPoint point1 = series.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(0, 1, 1, 10.0),   // X value
                workbook.GetCell(0, 1, 2, 20.0),   // Y value
                workbook.GetCell(0, 1, 3, 30.0));  // Bubble size

            // Point 2
            IChartDataPoint point2 = series.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(0, 2, 1, 15.0),
                workbook.GetCell(0, 2, 2, 25.0),
                workbook.GetCell(0, 2, 3, 40.0));

            // Point 3
            IChartDataPoint point3 = series.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(0, 3, 1, 20.0),
                workbook.GetCell(0, 3, 2, 30.0),
                workbook.GetCell(0, 3, 3, 50.0));

            // Assign individual colors to each bubble (optional, demonstrates manual coloring)
            point1.Format.Fill.FillType = FillType.Solid;
            point1.Format.Fill.SolidFillColor.Color = Color.Red;

            point2.Format.Fill.FillType = FillType.Solid;
            point2.Format.Fill.SolidFillColor.Color = Color.Green;

            point3.Format.Fill.FillType = FillType.Solid;
            point3.Format.Fill.SolidFillColor.Color = Color.Blue;

            // Save the presentation
            try
            {
                presentation.Save("BubbleChart.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other save errors
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}