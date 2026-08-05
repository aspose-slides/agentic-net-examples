// -----------------------------------------------------------------------------
// Example: Handle ArgumentException for unsupported layout target type using C#
//
// Description:
// Demonstrates how to handle an ArgumentException when setting an unsupported
// LayoutTargetType value on a chart's PlotArea using Aspose.Slides for .NET.
// The example creates a presentation, adds a clustered column chart, attempts
// to assign an invalid LayoutTargetType, catches the resulting exception, and
// falls back to a supported value before saving the file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, ArgumentException, Unsupported,
// LayoutTargetType, Chart, PlotArea, Presentation Processing, Office Automation
//
// Use Cases:
// - Safely handle invalid enum assignments when configuring chart layouts.
// - Build robust .NET tools for PowerPoint chart manipulation.
// - Automate PPTX generation with error handling for layout settings.
// - Validate chart configuration before publishing presentations.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "ChartLayoutExample.pptx";

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20f, 100f, 600f, 400f);

            // Manually define plot area layout
            chart.PlotArea.AsILayoutable.X = 0.2f;
            chart.PlotArea.AsILayoutable.Y = 0.2f;
            chart.PlotArea.AsILayoutable.Width = 0.7f;
            chart.PlotArea.AsILayoutable.Height = 0.7f;

            try
            {
                // Attempt to set an unsupported LayoutTargetType value
                chart.PlotArea.LayoutTargetType = (LayoutTargetType)999;
            }
            catch (ArgumentException ex)
            {
                // Handle the exception for unsupported enum value
                Console.WriteLine("ArgumentException caught: " + ex.Message);
                // Fallback to a supported value
                chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
            }

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}
