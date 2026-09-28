// -----------------------------------------------------------------------------
// Example: Hide Chart Title While Keeping Axis Labels in PowerPoint using C#
// 
// Description:
// This console application creates a new PowerPoint presentation, adds a
// clustered column chart, disables the chart title, and saves the file as a
// PPTX. It demonstrates how to customize chart appearance with Aspose.Slides
// for .NET while preserving axis labels.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, hide chart title, axis labels
// 
// Use Cases:
// - Generate reports where chart titles are redundant or handled elsewhere.
// - Programmatically format charts for corporate branding guidelines.
// - Automate slide creation with customized chart visuals.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define output file path
                string outputPath = "ChartWithoutTitle.pptx";

                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart (float parameters required)
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f,   // X position
                    50f,   // Y position
                    500f,  // Width
                    400f   // Height
                );

                // Hide the chart title while keeping axis labels intact
                chart.HasTitle = false;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                Console.WriteLine($"Presentation saved successfully to '{Path.GetFullPath(outputPath)}'.");
            }
            catch (NotSupportedException nsEx)
            {
                Console.WriteLine("The specified file format is not supported: " + nsEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
