using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie,
            50f, 50f, 400f, 400f);

        // Set chart title
        chart.ChartTitle.AddTextFrameForOverriding("Sample Pie Chart");
        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
        chart.ChartTitle.Height = 20f;
        chart.HasTitle = true;

        // Show values on the first series
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

        // Prepare workbook for chart data
        int defaultWorksheetIndex = 0;
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

        // Add a new series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
            workbook.GetCell(0, 0, 1, "Series 1"),
            chart.Type);

        // Populate series data points
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 30));
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 20));

        // Enable varied colors for each slice
        series.ParentSeriesGroup.IsColorVaried = true;

        // Save the presentation
        presentation.Save("PieChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}