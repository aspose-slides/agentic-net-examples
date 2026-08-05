// -----------------------------------------------------------------------------
// Example: Set chart background gradient with custom colors using C#
//
// Description:
// Demonstrates how to set a chart's background fill to a linear gradient with
// custom blue and orange colors using C# and Aspose.Slides for .NET. The
// example creates a presentation, adds a clustered column chart, applies the
// gradient fill, and saves the result as a PPTX file. This pattern can be used
// to automate PowerPoint chart styling in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Background, Gradient,
// Custom Colors, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting chart background gradients with custom colors.
// - Build C# tools for PowerPoint presentation processing and styling.
// - Generate or transform PPTX files with customized chart appearances.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Presentation();
            var slide = presentation.Slides[0];
            var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Set chart background fill to a gradient with custom colors
            chart.FillFormat.FillType = FillType.Gradient;
            chart.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
            chart.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;
            chart.FillFormat.GradientFormat.GradientStops.Add(0, System.Drawing.Color.FromArgb(255, 0, 128, 255)); // custom blue
            chart.FillFormat.GradientFormat.GradientStops.Add(1, System.Drawing.Color.FromArgb(255, 255, 128, 0)); // custom orange

            var outputPath = "ChartGradientBackground.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
        }
    }
}
