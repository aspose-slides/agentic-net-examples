// -----------------------------------------------------------------------------
// Example: Change marker style while preserving error bars using C#
//
// Description:
// Demonstrates how to change the marker style of a chart series while preserving
// any existing error bars using C# and Aspose.Slides for .NET. The example
// creates or loads a presentation, adds a clustered column chart if needed,
// modifies the first series marker to a circular style with a specific size,
// and saves the result. This pattern can be used to automate chart styling
// tasks in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Change, Marker, Style, While,
// Presentation Processing, Office Automation, Error Bars
//
// Use Cases:
// - Automate changing marker styles while keeping error bars intact.
// - Build C# tools for PowerPoint chart customization.
// - Generate or transform PPTX files with specific chart aesthetics.
// - Validate and process presentation workflows before publishing.
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
        string dataDir = "Data";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        Presentation pres = null;
        try
        {
            if (File.Exists(inputPath))
            {
                pres = new Presentation(inputPath);
            }
            else
            {
                pres = new Presentation();
            }

            IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            if (chart.ChartData.Series.Count == 0)
            {
                IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;
                chart.ChartData.Series.Add(wb.GetCell(0, 0, 1, "Series 1"), ChartType.ClusteredColumn);
                chart.ChartData.Categories.Add(wb.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(wb.GetCell(0, 2, 0, "Category 2"));
                IChartSeries series = chart.ChartData.Series[0];
                series.DataPoints.AddDataPointForBarSeries(wb.GetCell(0, 1, 1, 10));
                series.DataPoints.AddDataPointForBarSeries(wb.GetCell(0, 2, 1, 20));
            }

            IChartSeries firstSeries = chart.ChartData.Series[0];
            IMarker marker = firstSeries.Marker;
            marker.Symbol = MarkerStyleType.Circle;
            marker.Size = 10;

            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (pres != null)
            {
                pres.Dispose();
            }
        }
    }
}
