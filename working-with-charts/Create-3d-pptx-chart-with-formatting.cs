using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get a blank layout slide
        Aspose.Slides.ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);

        // Add a new slide based on the blank layout
        Aspose.Slides.ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Add a 3D clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn3D, 50f, 50f, 600f, 400f);

        // Set chart title
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("3D Column Chart");
        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

        // Access the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add categories
        Aspose.Slides.Charts.IChartCategory category1 = chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
        Aspose.Slides.Charts.IChartCategory category2 = chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
        Aspose.Slides.Charts.IChartCategory category3 = chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

        // Add series
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), Aspose.Slides.Charts.ChartType.ClusteredColumn3D);
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), Aspose.Slides.Charts.ChartType.ClusteredColumn3D);

        // Populate series data
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 30));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 10));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 60));

        // Set series colors
        series1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        series1.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Red;

        series2.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        series2.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Green;

        // Access the first series group to set 3D formatting properties
        Aspose.Slides.Charts.IChartSeriesGroup seriesGroup = chart.ChartData.SeriesGroups[0];
        seriesGroup.GapDepth = (ushort)150; // percentage

        // Configure 3D rotation
        Aspose.Slides.Charts.IRotation3D rotation = chart.Rotation3D;
        rotation.RotationX = 20;
        rotation.RotationY = 30;
        rotation.DepthPercents = (ushort)200;
        rotation.HeightPercents = (ushort)100;
        rotation.Perspective = (byte)30;
        rotation.RightAngleAxes = false;

        // Format back wall
        Aspose.Slides.Charts.IChartWall backWall = chart.BackWall;
        backWall.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        backWall.Format.Fill.SolidFillColor.Color = System.Drawing.Color.LightGray;

        // Format floor
        Aspose.Slides.Charts.IChartWall floor = chart.Floor;
        floor.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        floor.Format.Fill.SolidFillColor.Color = System.Drawing.Color.LightGray;

        // Format side wall
        Aspose.Slides.Charts.IChartWall sideWall = chart.SideWall;
        sideWall.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        sideWall.Format.Fill.SolidFillColor.Color = System.Drawing.Color.LightGray;

        // Save the presentation
        string outputPath = "3DChartPresentation.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}