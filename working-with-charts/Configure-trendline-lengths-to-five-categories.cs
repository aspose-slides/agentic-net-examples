// -----------------------------------------------------------------------------
// Example: Configure trendline lengths to five categories using C#
//
// Description:
// Demonstrates how to configure a linear trendline's forward and backward
// lengths to five categories (value of 5) for a chart in a PowerPoint
// presentation using Aspose.Slides for .NET. The example creates a presentation,
// adds a clustered column chart, applies a linear trendline to the first data
// series, sets the trendline length forward and backward to 5, and saves the
// result as a PPTX file. This pattern can be used to automate trendline
// configuration in chart-driven presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Configure, Trendline, Lengths,
// Five, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting trendline lengths to a specific value across chart categories.
// - Build C# tools for PowerPoint presentation processing that require trendline customization.
// - Generate or transform PPTX files with predefined chart analytics in .NET applications.
// - Validate presentation workflows involving chart trendlines before publishing or integration.
// -----------------------------------------------------------------------------

using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Presentation presentation = new Presentation();
                ISlide slide = presentation.Slides[0];
                Charts.IChart chart = slide.Shapes.AddChart(Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Add a linear trendline to the first series and set its length forward and backward to 5
                Charts.ITrendline trendline = chart.ChartData.Series[0].TrendLines.Add(Charts.TrendlineType.Linear);
                trendline.Forward = 5;
                trendline.Backward = 5;

                // Save the presentation
                presentation.Save("TrendlineForwardBackward.pptx", SaveFormat.Pptx);
            }
            catch (System.Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
