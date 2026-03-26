using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        using (Presentation presentation = new Presentation())
        {
            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a 3D clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 50, 50, 500, 400);

            // Set chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("3D Chart Example");
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;

            // Configure 3D rotation
            IRotation3D rotation = chart.Rotation3D;
            rotation.DepthPercents = 200;      // Depth as percent of chart width
            rotation.HeightPercents = 150;     // Height as percent of chart width
            rotation.Perspective = 30;         // Perspective angle
            rotation.RotationX = 20;           // X-axis rotation
            rotation.RotationY = 30;           // Y-axis rotation
            rotation.RightAngleAxes = false;   // Use perspective

            // Prepare chart data
            int defaultWorksheetIndex = 0;
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Add series
            IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
            IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

            // Populate series data
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));

            // Set fill colors for series
            series1.Format.Fill.FillType = FillType.Solid;
            series1.Format.Fill.SolidFillColor.Color = Color.Red;

            series2.Format.Fill.FillType = FillType.Solid;
            series2.Format.Fill.SolidFillColor.Color = Color.Blue;

            // Save the presentation
            presentation.Save("3DChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}