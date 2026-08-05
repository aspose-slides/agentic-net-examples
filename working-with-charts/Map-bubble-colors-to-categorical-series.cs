// -----------------------------------------------------------------------------
// Example: Map bubble colors to categorical series using C#
//
// Description:
// Demonstrates how to map bubble colors to categorical series using C# and 
// Aspose.Slides for .NET. The example creates a bubble chart, assigns distinct
// colors to each bubble to represent categorical data, and saves the result as
// a PowerPoint presentation. This pattern helps automate PPTX workflows,
// validate visual data representations, or integrate presentation logic into
// .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bubble, Colors, Categorical, 
// Series, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate mapping of bubble colors to categorical series in presentations.
// - Build C# tools for PowerPoint chart customization and processing.
// - Generate or transform PPTX files with colored bubble charts in .NET apps.
// - Validate chart visualizations before publishing or integration.
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
        string outputPath = "BubbleChart.pptx";
        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a bubble chart
            IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50f, 50f, 600f, 400f);

            // Set bubble size representation to Width
            chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;

            // Get the workbook to add data
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add a series
            IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "A1", "Series 1"), ChartType.Bubble);

            // First data point
            IChartDataCell x1 = workbook.GetCell(0, "B2", 1);
            IChartDataCell y1 = workbook.GetCell(0, "C2", 4);
            IChartDataCell size1 = workbook.GetCell(0, "D2", 30);
            IChartDataPoint point1 = series.DataPoints.AddDataPointForBubbleSeries(x1, y1, size1);
            point1.Format.Fill.FillType = FillType.Solid;
            point1.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Red;

            // Second data point
            IChartDataCell x2 = workbook.GetCell(0, "B3", 2);
            IChartDataCell y2 = workbook.GetCell(0, "C3", 5);
            IChartDataCell size2 = workbook.GetCell(0, "D3", 40);
            IChartDataPoint point2 = series.DataPoints.AddDataPointForBubbleSeries(x2, y2, size2);
            point2.Format.Fill.FillType = FillType.Solid;
            point2.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Green;

            // Third data point
            IChartDataCell x3 = workbook.GetCell(0, "B4", 3);
            IChartDataCell y3 = workbook.GetCell(0, "C4", 2);
            IChartDataCell size3 = workbook.GetCell(0, "D4", 20);
            IChartDataPoint point3 = series.DataPoints.AddDataPointForBubbleSeries(x3, y3, size3);
            point3.Format.Fill.FillType = FillType.Solid;
            point3.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Blue;

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
