// -----------------------------------------------------------------------------
// Example: Set plot area layouttargettype to outside using C#
//
// Description:
// Demonstrates how to set the plot area LayoutTargetType to Outer (outside) using
// C# and Aspose.Slides for .NET. The example creates a presentation, adds a
// clustered column chart, defines a manual layout for the plot area, sets the
// LayoutTargetType to Outer so that axes are included within the plotted region,
// and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, PlotArea, LayoutTargetType, 
// Outer, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting plot area layout target to outside in PowerPoint charts.
// - Build C# tools for chart layout customization in presentations.
// - Generate or modify PPTX files with specific chart configurations.
// - Validate chart layout behavior before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartLayoutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    20f, 100f, 600f, 400f);

                // Define manual layout for the plot area
                chart.PlotArea.AsILayoutable.X = 0.2f;
                chart.PlotArea.AsILayoutable.Y = 0.2f;
                chart.PlotArea.AsILayoutable.Width = 0.7f;
                chart.PlotArea.AsILayoutable.Height = 0.7f;

                // Set LayoutTargetType to Outer so axes are included within the plotted region
                chart.PlotArea.LayoutTargetType = Aspose.Slides.Charts.LayoutTargetType.Outer;

                // Save the presentation
                presentation.Save("ChartLayoutOuter.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., unsupported format, I/O errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
