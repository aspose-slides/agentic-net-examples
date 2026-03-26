using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlides3DChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a 3D clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn3D,
                50f, 50f, 500f, 400f);

            // Configure the chart to position axis between categories (using provided rule)
            chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Q1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Q2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Q3"));

            // Add first series
            Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 1, "Series 1"),
                Aspose.Slides.Charts.ChartType.ClusteredColumn3D);
            // Populate data points for first series
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));
            // Set fill color for first series
            series1.Format.Fill.FillType = FillType.Solid;
            series1.Format.Fill.SolidFillColor.Color = Color.Red;

            // Add second series
            Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 2, "Series 2"),
                Aspose.Slides.Charts.ChartType.ClusteredColumn3D);
            // Populate data points for second series
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 30));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 10));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 60));
            // Set fill color for second series
            series2.Format.Fill.FillType = FillType.Solid;
            series2.Format.Fill.SolidFillColor.Color = Color.Green;

            // Configure 3D rotation (depth, perspective, rotation angles)
            chart.Rotation3D.DepthPercents = 200;      // Depth as percentage of chart width
            chart.Rotation3D.HeightPercents = 100;     // Height as percentage of chart width
            chart.Rotation3D.Perspective = 30;         // Perspective angle
            chart.Rotation3D.RotationX = 20;           // X‑axis rotation
            chart.Rotation3D.RotationY = 30;           // Y‑axis rotation
            chart.Rotation3D.RightAngleAxes = false;   // Use perspective axes

            // Save the presentation
            presentation.Save("3DChartOutput.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}