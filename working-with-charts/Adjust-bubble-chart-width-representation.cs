// -----------------------------------------------------------------------------
// Example: Adjust Bubble Chart Width Representation in PowerPoint using Aspose.Slides
//
// Description:
// This console application demonstrates how to create a new PowerPoint presentation,
// add a bubble chart, and set its bubble size representation to Width using Aspose.Slides for .NET.
// The resulting PPTX file shows the customized bubble chart appearance suitable for automated slide generation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, bubble chart, BubbleSizeRepresentation, Width
//
// Use Cases:
// - Generate reports with bubble charts where bubble width reflects data values.
// - Automate slide creation for business analytics dashboards.
// - Customize chart appearance programmatically in batch processing.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace BubbleChartWidthExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "BubbleChartWidthRepresentation.pptx";

            try
            {
                // Ensure the output directory exists
                string outputDirectory = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(outputDirectory) && !Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a bubble chart to the first slide
                Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Bubble,
                    50f,   // X position
                    50f,   // Y position
                    500f,  // Width
                    400f   // Height
                );

                // Set bubble size representation to Width
                chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Clean up
                presentation.Dispose();

                Console.WriteLine("Presentation saved successfully to: " + Path.GetFullPath(outputPath));
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
