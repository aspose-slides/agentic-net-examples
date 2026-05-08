using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            // Add a doughnut chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Doughnut, 50, 50, 400, 400);
            // Set doughnut hole size (percentage of plot area)
            chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = 50;
            // Clear any default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();
            // Prepare workbook and default worksheet index
            int defaultWorksheetIndex = 0;
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category C"));
            // Add a series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
            // Add data points for each slice
            series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 30));
            series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
            series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 20));
            // Show both value and percentage on data labels
            series.Labels.DefaultDataLabelFormat.ShowValue = true;
            series.Labels.DefaultDataLabelFormat.ShowPercentage = true;
            // Save the presentation
            presentation.Save("DoughnutChartWithLabels.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other exceptions
            // For unsupported format, comment: format not supported
        }
    }
}