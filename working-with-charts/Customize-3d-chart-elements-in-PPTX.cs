using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a 3D stacked column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.StackedColumn3D,
            0f, 0f, 500f, 500f);

        // Prepare workbook and default worksheet index
        int defaultWorksheetIndex = 0;
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

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

        // Set 3D rotation properties
        chart.Rotation3D.RightAngleAxes = true;
        chart.Rotation3D.RotationX = -30; // SByte
        chart.Rotation3D.RotationY = 40;  // UInt16
        chart.Rotation3D.DepthPercents = 150; // UInt16

        // Populate first series data points
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[0];
        series1.DataPoints.AddDataPointForBarSeries(
            workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
        series1.DataPoints.AddDataPointForBarSeries(
            workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
        series1.DataPoints.AddDataPointForBarSeries(
            workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

        // Populate second series data points
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series[1];
        series2.DataPoints.AddDataPointForBarSeries(
            workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
        series2.DataPoints.AddDataPointForBarSeries(
            workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
        series2.DataPoints.AddDataPointForBarSeries(
            workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));

        // Set series overlap
        series2.ParentSeriesGroup.Overlap = -20; // SByte

        // Save the presentation
        string outputPath = "Custom3DChart.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}