// -----------------------------------------------------------------------------
// Example: Set bubble size representation to width using C#
//
// Description:
// Demonstrates how to set the bubble size representation to Width for a bubble
// chart using C# and Aspose.Slides for .NET. The example creates a new
// presentation, adds a bubble chart, modifies the first series group's bubble
// size representation, and saves the result as a PPTX file. This pattern can be
// used to automate PowerPoint chart customizations in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bubble Chart, Size Representation,
// Width, Chart Customization, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting bubble size representation to Width in presentations.
// - Build C# tools for customizing chart appearance in PowerPoint files.
// - Generate or modify PPTX files with specific chart settings in .NET apps.
// - Validate chart configurations before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a bubble chart
                IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50f, 50f, 600f, 400f);

                // Change bubble size representation to Width for the first series group
                chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;

                // Save the presentation
                presentation.Save("BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
