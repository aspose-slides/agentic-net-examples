using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the workbook to add data
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 1, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 2, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 3, "Category 3"));

            // Add a series
            chart.ChartData.Series.Add(workbook.GetCell(0, 1, 0, "Series 1"), chart.Type);
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Add data points
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 10));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 3, 15));

            // Set error bars to show both positive and negative directions
            series.ErrorBarsYFormat.Type = Aspose.Slides.Charts.ErrorBarType.Both;
            series.ErrorBarsYFormat.IsVisible = true;

            // Save the presentation
            presentation.Save("ColumnChartWithErrorBars.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException ex)
        {
            // Handle missing file scenario
            Console.WriteLine("File not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General exception handling (including unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}