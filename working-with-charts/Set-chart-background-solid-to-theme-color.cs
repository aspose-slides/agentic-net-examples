// -----------------------------------------------------------------------------
// Example: Set Chart Background to Theme Accent Color using Aspose.Slides
//
// Description:
// This console application creates a new PowerPoint presentation, adds a
// clustered column chart, applies a solid fill background using a theme
// accent color, and saves the file as PPTX. It demonstrates chart creation
// and background styling with Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, chart background, theme color, solid fill
//
// Use Cases:
// - Automating report generation with styled charts.
// - Applying corporate theme colors to chart backgrounds programmatically.
// - Generating presentations without manual PowerPoint editing.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;

namespace ChartBackgroundExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "ChartBackgroundThemeColor.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Define chart position and size (float literals)
                float chartX = 50f;
                float chartY = 50f;
                float chartWidth = 500f;
                float chartHeight = 400f;

                // Add a clustered column chart to the first slide
                Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    chartX, chartY, chartWidth, chartHeight);

                // Set chart background to a solid fill using a theme accent color
                chart.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                chart.FillFormat.SolidFillColor.SchemeColor = Aspose.Slides.SchemeColor.Accent2;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Clean up
                presentation.Dispose();

                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
