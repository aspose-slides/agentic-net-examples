// -----------------------------------------------------------------------------
// Example: Set chart background solid color using C#
//
// Description:
// Demonstrates how to set a chart's background to a solid color using C# and 
// Aspose.Slides for .NET. The example creates a presentation, adds a clustered 
// column chart, applies a theme accent color as the chart's background fill, 
// and saves the result as a PPTX file. This pattern can be used to automate 
// PowerPoint chart styling in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Background, Solid, 
// Color, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting a chart's background to a solid color.
// - Build C# tools for PowerPoint chart styling and processing.
// - Generate or modify PPTX files with customized chart appearances.
// - Validate chart formatting workflows before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetChartBackgroundSolidColor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a chart to the slide
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 400, 300);

                // Retrieve a theme accent color (e.g., Accent1) from the presentation's master theme
                Aspose.Slides.Theme.IColorScheme colorScheme = pres.MasterTheme.ColorScheme;
                Color themeColor = colorScheme.Accent1.Color;

                // Set the chart's background fill to a solid color matching the theme accent color
                chart.FillFormat.FillType = FillType.Solid;
                chart.FillFormat.SolidFillColor.Color = themeColor;

                // Save the presentation
                try
                {
                    pres.Save("ChartBackgroundSolidColor.pptx", SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    // Handle unsupported format or other save errors
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
        }
    }
}
