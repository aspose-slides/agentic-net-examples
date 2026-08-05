// -----------------------------------------------------------------------------
// Example: Abstract plot area operations with ichartplotarea using C#
//
// Description:
// Demonstrates how to abstract plot area operations with ichartplotarea using 
// C# and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Abstract, Plot, Area, 
// Operations, Presentation Processing, Office Automation, Chart, IChartPlotArea
//
// Use Cases:
// - Automate abstract plot area operations with ichartplotarea.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartPlotAreaExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "ChartPlotAreaExample.pptx";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20f, 100f, 600f, 400f);

                // Use IChartPlotArea to set plot area layout
                chart.PlotArea.AsILayoutable.X = 0.2f;
                chart.PlotArea.AsILayoutable.Y = 0.2f;
                chart.PlotArea.AsILayoutable.Width = 0.7f;
                chart.PlotArea.AsILayoutable.Height = 0.7f;
                chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, external resources)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
