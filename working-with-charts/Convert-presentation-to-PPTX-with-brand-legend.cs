// -----------------------------------------------------------------------------
// Example: Convert presentation to PPTX with branded chart legends using C#
//
// Description:
// Demonstrates how to load a PPTX presentation, iterate through its slides,
// find chart objects, apply branded legend positioning and formatting, and
// save the modified presentation as PPTX using Aspose.Slides for .NET.
// This example is useful for automating chart legend branding in PowerPoint
// files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Legend, Branding,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Apply corporate branding to chart legends across a presentation.
// - Automate the adjustment of legend position, size, and style in PPTX files.
// - Build .NET tools for consistent chart appearance in PowerPoint reports.
// - Validate and enforce legend formatting before publishing presentations.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartLegendBranding
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation inside a try-catch to handle unsupported formats
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Iterate through all slides and adjust chart legends
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    if (slide.Shapes[shapeIndex] is Aspose.Slides.Charts.IChart)
                    {
                        Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)slide.Shapes[shapeIndex];

                        // Ensure the chart has a legend
                        chart.HasLegend = true;

                        // Adjust legend position and size to match branding guidelines
                        chart.Legend.X = 0.1f;          // 10% from the left
                        chart.Legend.Y = 0.9f;          // 90% from the top
                        chart.Legend.Width = 0.3f;      // 30% of chart width
                        chart.Legend.Height = 0.1f;     // 10% of chart height
                        chart.Legend.Overlay = false;  // Do not allow overlap

                        // Optionally, set legend text format (font size) if needed
                        chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;
                    }
                }
            }

            // Save the modified presentation as PPTX
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
