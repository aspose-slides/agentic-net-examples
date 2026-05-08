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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 1, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 2, "Category 3"));

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
            // Handle missing input file
            Console.WriteLine("Input file not found: " + ex.Message);
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}