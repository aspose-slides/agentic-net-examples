// -----------------------------------------------------------------------------
// Example: Set axis major unit to ten using C#
//
// Description:
// Demonstrates how to set the vertical axis major unit to ten in a clustered
// column chart using Aspose.Slides for .NET. The example creates a new
// presentation, adds a chart, disables automatic major unit calculation, sets
// the major unit to 10, and saves the file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Axis, Major Unit, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically configure chart axis scaling.
// - Generate PowerPoint reports with consistent chart intervals.
// - Automate presentation creation with custom chart settings.
// - Ensure uniform tick spacing across multiple generated charts.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);

            // Disable automatic major unit calculation
            chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;

            // Set major unit to 10 for uniform tick spacing
            chart.Axes.VerticalAxis.MajorUnit = 10;

            // Save the presentation
            presentation.Save("AxisMajorUnit.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format exception
            // Format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
