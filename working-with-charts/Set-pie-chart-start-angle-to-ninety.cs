// -----------------------------------------------------------------------------
// Example: Set pie chart start angle to ninety using C#
//
// Description:
// Demonstrates how to set the start angle of a pie chart to ninety degrees 
// using C# and Aspose.Slides for .NET. The example creates a new presentation, 
// adds a pie chart, configures the first slice start angle, and saves the 
// presentation as a PPTX file. This pattern can be used to automate chart 
// formatting tasks in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Pie Chart, Start Angle, 
// Ninety Degrees, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting pie chart start angle to ninety degrees.
// - Build C# utilities for PowerPoint chart customization.
// - Generate or modify PPTX files with specific chart configurations.
// - Validate chart appearance programmatically before publishing.
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
            // Create a new presentation
            Presentation presentation = new Presentation();
            // Access the first slide
            ISlide slide = presentation.Slides[0];
            // Add a pie chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50f, 50f, 400f, 400f);
            // Set the start angle of the first slice to 90 degrees
            chart.ChartData.Series[0].ParentSeriesGroup.FirstSliceAngle = 90;
            // Save the presentation
            try
            {
                presentation.Save("PieChart_StartAngle.pptx", SaveFormat.Pptx);
            }
            catch (Exception)
            {
                // Format not supported or other save error
            }
        }
    }
}
