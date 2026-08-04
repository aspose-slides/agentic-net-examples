// -----------------------------------------------------------------------------
// Example: Check if chart data table is visible using C#
//
// Description:
// Demonstrates how to determine whether a chart's data table is visible in a
// PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// loads a PPTX file, accesses the first chart on the first slide, checks the
// HasDataTable property, outputs the result, and saves the presentation.
// This pattern helps developers automate validation of chart data tables in
// PPTX files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Data Table, Visibility,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Verify if a chart's data table is displayed before publishing.
// - Build tools that audit PowerPoint files for chart data table presence.
// - Integrate chart visibility checks into .NET automation workflows.
// - Ensure consistency of chart data tables across multiple presentations.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes[0] as Aspose.Slides.Charts.IChart;
            if (chart != null)
            {
                bool isVisible = IsChartDataTableVisible(chart);
                Console.WriteLine("Data table visible: " + isVisible);
            }
            else
            {
                Console.WriteLine("No chart found on first slide.");
            }

            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., external URLs)
        }
    }

    static bool IsChartDataTableVisible(Aspose.Slides.Charts.IChart chart)
    {
        return chart.HasDataTable;
    }
}
