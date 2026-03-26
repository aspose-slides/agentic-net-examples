using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 450f, 300f);

        // Set the horizontal axis to be positioned between categories
        chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

        // Show display unit label in millions on the vertical axis
        chart.Axes.VerticalAxis.DisplayUnit = Aspose.Slides.Charts.DisplayUnitType.Millions;

        // Set category axis label distance
        chart.Axes.HorizontalAxis.LabelOffset = (ushort)10;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the workbook to add custom data
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        int defaultWorksheetIndex = 0;

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

        // Add first series and its data points
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
            workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
            chart.Type);
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));
        series1.Format.Fill.FillType = FillType.Solid;

        // Add second series and its data points
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
            workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"),
            chart.Type);
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));
        series2.Format.Fill.FillType = FillType.Solid;

        // Switch rows and columns if needed
        chart.ChartData.SwitchRowColumn();

        // Save the presentation
        string outputPath = "ClusteredColumnChart.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}