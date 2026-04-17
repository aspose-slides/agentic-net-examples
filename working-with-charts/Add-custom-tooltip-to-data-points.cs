using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        string outputPath = "CustomTooltipChart.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a pie chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 500, 400);

        // Remove default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get default worksheet index
        int defaultWorksheetIndex = 0;
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add a series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

        // Define categories and values
        string[] categories = new string[] { "Apple", "Banana", "Cherry" };
        double[] values = new double[] { 30, 45, 25 };

        // Populate categories and data points
        for (int i = 0; i < categories.Length; i++)
        {
            // Add category
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, i + 1, 0, categories[i]));
            // Add data point for the series
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, i + 1, 1, values[i]));
        }

        // Show data labels as callouts
        series.Labels.DefaultDataLabelFormat.ShowValue = true;
        series.Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

        // Add custom tooltip (override label text) for each data point
        for (int i = 0; i < series.DataPoints.Count; i++)
        {
            Aspose.Slides.Charts.IChartDataPoint dataPoint = series.DataPoints[i];
            Aspose.Slides.Charts.IDataLabel dataLabel = dataPoint.Label;

            // Build custom tooltip text
            string tooltip = string.Format("{0}: {1} units ({2:P1})", categories[i], values[i], values[i] / 100);

            // Override the label text with the custom tooltip
            dataLabel.AddTextFrameForOverriding(tooltip);
        }

        // Save the presentation (handle unsupported format)
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported or other save error
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}