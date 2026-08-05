// -----------------------------------------------------------------------------
// Example: Create comparison presentation with multiple chart types using C#
//
// Description:
// Demonstrates how to create a comparison presentation that showcases a variety
// of chart types using C# and Aspose.Slides for .NET. The example builds a PowerPoint
// file where each slide contains a different chart type with sample data, sets a
// title indicating the chart type, and saves the result as a PPTX file. This pattern
// helps developers automate chart comparison scenarios, generate sample presentations,
// or validate chart rendering in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Comparison, Presentation,
// Multiple, Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of a presentation that compares multiple chart types.
// - Build C# tools for generating sample PowerPoint files with diverse charts.
// - Validate chart rendering and formatting across different chart types.
// - Integrate chart generation into .NET applications for reporting or analytics.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartComparisonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Define an array of different chart types to compare
            ChartType[] chartTypes = new ChartType[]
            {
                ChartType.ClusteredColumn,
                ChartType.StackedColumn,
                ChartType.Pie,
                ChartType.Line,
                ChartType.Area,
                ChartType.ScatterWithMarkers,
                ChartType.BarOfPie,
                ChartType.Doughnut,
                ChartType.Bubble,
                ChartType.Radar
            };

            // Loop through each chart type and add a slide with the chart
            for (int i = 0; i < chartTypes.Length; i++)
            {
                // Add a new empty slide (use the layout of the first slide)
                ISlide slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

                // Add a chart with sample data to the slide
                IChart chart = slide.Shapes.AddChart(chartTypes[i], 50f, 50f, 500f, 400f);

                // Set chart title to indicate the chart type
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding(chartTypes[i].ToString());
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
                chart.ChartTitle.Height = 20f;
            }

            try
            {
                // Save the presentation
                presentation.Save("ChartComparison.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions such as unsupported format
                // Format not supported
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                presentation.Dispose();
            }
        }
    }
}
