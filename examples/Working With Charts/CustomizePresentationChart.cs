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
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Enable and set the chart title
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
        chart.ChartTitle.Height = 20f;

        // Remove default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the default worksheet index and workbook
        int defaultWorksheetIndex = 0;
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add categories (e.g., quarters)
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Q1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Q2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Q3"));

        // Add two series
        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Product A"), chart.Type);
        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Product B"), chart.Type);

        // Populate data for the first series
        Aspose.Slides.Charts.IChartSeries series0 = chart.ChartData.Series[0];
        series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 120));
        series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 150));
        series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 180));

        // Populate data for the second series
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[1];
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 80));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 130));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 170));

        // Set fill colors for the series
        series0.Format.Fill.FillType = FillType.Solid;
        series0.Format.Fill.SolidFillColor.Color = Color.Blue;

        series1.Format.Fill.FillType = FillType.Solid;
        series1.Format.Fill.SolidFillColor.Color = Color.Orange;

        // Show values on data labels
        series0.Labels.DefaultDataLabelFormat.ShowValue = true;
        series1.Labels.DefaultDataLabelFormat.ShowValue = true;

        // Save the presentation
        presentation.Save("CustomizedChart.pptx", SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}