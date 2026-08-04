// -----------------------------------------------------------------------------
// Example: Apply chart legend right position using C#
//
// Description:
// Demonstrates how to apply a chart legend right position using C# and 
// Aspose.Slides for .NET. The example creates a new presentation, adds a 
// clustered column chart, sets the legend position to the right side, and 
// saves the result as a PPTX file. This pattern can be used to automate PPTX 
// workflows, validate chart formatting, or integrate presentation logic into 
// .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Chart, Legend, Right, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying chart legend right position.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartLegendExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Add a clustered column chart to the first slide
                Aspose.Slides.Charts.Chart chart = (Aspose.Slides.Charts.Chart)pres.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50,   // X position
                    50,   // Y position
                    500,  // Width
                    400   // Height
                );

                // Validate layout to ensure actual values are calculated
                chart.ValidateChartLayout();

                // Access the legend and set its position to the right side
                Aspose.Slides.Charts.Legend legend = (Aspose.Slides.Charts.Legend)chart.Legend;
                legend.Position = Aspose.Slides.Charts.LegendPositionType.Right;

                // Save the presentation
                pres.Save("ChartWithRightLegend.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
