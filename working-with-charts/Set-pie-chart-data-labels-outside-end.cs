using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a pie chart
        IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

        // Set chart title (optional)
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("Sample Pie Chart");
        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
        chart.ChartTitle.Height = 20;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get default workbook
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

        // Add series
        IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

        // Add data points
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 1, 1, 20));
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 2, 1, 30));
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 3, 1, 50));

        // Set data label position to OutsideEnd for all data labels in the series
        series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;

        // Save the presentation
        try
        {
            presentation.Save("PieChartOutsideEnd.pptx", SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported or other error handling
        }
    }
}