using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "BubbleChart.pptx";

        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a bubble chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50f, 50f, 600f, 400f);

            // Set bubble size representation to Width
            chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add a new series
            IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

            // Add data points (X value, Y value, Bubble size)
            series.DataPoints.AddDataPointForBubbleSeries(10.0, 20.0, workbook.GetCell(0, 1, 1, 30.0));
            series.DataPoints.AddDataPointForBubbleSeries(15.0, 25.0, workbook.GetCell(0, 2, 1, 40.0));
            series.DataPoints.AddDataPointForBubbleSeries(20.0, 30.0, workbook.GetCell(0, 3, 1, 50.0));

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Error: Required file not found - " + ex.FileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}