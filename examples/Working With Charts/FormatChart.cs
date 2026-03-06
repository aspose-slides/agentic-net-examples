using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Set chart title
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
        chart.ChartTitle.Height = 20;

        // Access chart data workbook
        int defaultWorksheetIndex = 0;
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Q1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Q2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Q3"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 4, 0, "Q4"));

        // Add series
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Product A"), chart.Type);
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Product B"), chart.Type);

        // Populate series data
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 120));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 150));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 170));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 200));

        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 80));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 130));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 160));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 190));

        // Set fill colors for series
        series1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        series1.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Blue;

        series2.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        series2.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Orange;

        // Show data labels for first series
        series1.Labels.DefaultDataLabelFormat.ShowValue = true;

        // Save the presentation
        presentation.Save("FormattedChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}