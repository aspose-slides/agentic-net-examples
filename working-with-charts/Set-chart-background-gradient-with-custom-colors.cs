// -----------------------------------------------------------------------------
// Example: Set Chart Background Gradient with Custom Colors using C#
// 
// Description:
// This console application demonstrates how to create a PowerPoint presentation,
// add a clustered column chart, and apply a linear gradient background with custom
// blue and orange colors using Aspose.Slides for .NET. The resulting PPTX file
// can be opened in PowerPoint to view the styled chart.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, chart background gradient, custom colors
// 
// Use Cases:
// - Automate chart styling in generated presentations.
// - Apply corporate branding colors to chart backgrounds programmatically.
// - Create consistent visual themes across multiple PowerPoint files.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;

namespace ChartGradientExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "ChartGradientExample.pptx";

            try
            {
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a clustered column chart to the slide
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f, 50f, 500f, 400f);

                // Configure the chart's background to use a linear gradient
                chart.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
                chart.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
                chart.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner1;

                // Add gradient stops: blue at the start, orange at the end
                chart.FillFormat.GradientFormat.GradientStops.Add(
                    0f,
                    System.Drawing.Color.FromArgb(0, 0, 255)); // Blue

                chart.FillFormat.GradientFormat.GradientStops.Add(
                    1f,
                    System.Drawing.Color.FromArgb(255, 165, 0)); // Orange

                // Save the presentation to a PPTX file
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
