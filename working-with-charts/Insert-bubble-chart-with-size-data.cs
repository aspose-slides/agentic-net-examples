// -----------------------------------------------------------------------------
// Example: Insert bubble chart with size data using C#
//
// Description:
// Demonstrates how to insert a bubble chart with size data into a PowerPoint
// presentation using C# and Aspose.Slides for .NET. The example creates a new
// presentation, adds a bubble chart, configures bubble size representation,
// populates categories and series with X, Y, and size values, enables bubble
// size labels, and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Bubble Chart, Size Data,
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of bubble charts with custom size data.
// - Build .NET tools for generating or modifying PPTX files.
// - Create data‑driven presentations with bubble visualizations.
// - Validate chart data and formatting in automated workflows.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "BubbleChart.pptx");
        try
        {
            Presentation pres = new Presentation();
            ISlide slide = pres.Slides[0];
            IChart chart = slide.Shapes.AddChart(ChartType.Bubble, 50f, 50f, 600f, 400f);
            chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;

            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            chart.ChartData.Categories.Clear();
            chart.ChartData.Series.Clear();

            chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));

            IChartSeries series = chart.ChartData.Series.Add(ChartType.Bubble);

            series.DataPoints.AddDataPointForBubbleSeries(workbook.GetCell(0, "B1", 1.0), workbook.GetCell(0, "C1", 4.0), workbook.GetCell(0, "D1", 10.0));
            series.DataPoints.AddDataPointForBubbleSeries(workbook.GetCell(0, "B2", 2.0), workbook.GetCell(0, "C2", 5.0), workbook.GetCell(0, "D2", 20.0));
            series.DataPoints.AddDataPointForBubbleSeries(workbook.GetCell(0, "B3", 3.0), workbook.GetCell(0, "C3", 6.0), workbook.GetCell(0, "D3", 30.0));

            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowBubbleSize = true;

            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
