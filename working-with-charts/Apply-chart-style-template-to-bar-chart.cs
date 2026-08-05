// -----------------------------------------------------------------------------
// Example: Apply chart style template to bar chart using C#
//
// Description:
// Demonstrates how to apply a predefined chart style template to a clustered
// column (bar) chart using C# and Aspose.Slides for .NET. The example creates a
// new presentation, adds a bar chart, sets the chart style, and saves the
// result as a PPTX file. This pattern can be used to automate styling of
// charts in PowerPoint presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Chart, Style, Template,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying a chart style template to bar charts.
// - Build C# utilities for consistent chart styling in PowerPoint files.
// - Generate styled PPTX presentations programmatically.
// - Ensure visual consistency across multiple presentations.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartStyleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "BarChartWithStyle.pptx";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column (bar) chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                // Apply a predefined chart style (e.g., Style5)
                chart.Style = StyleType.Style5;

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                // Handle missing input file scenario (if any input files were used)
                Console.WriteLine("Input file not found: " + ex.Message);
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                // Format not supported.
                Console.WriteLine("Format not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling for external services or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
