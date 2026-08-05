// -----------------------------------------------------------------------------
// Example: Remove chart legend from presentation using C#
//
// Description:
// Demonstrates how to remove chart legends from all charts in a PowerPoint
// presentation using C# and Aspose.Slides for .NET. The example loads an
// existing PPTX file, iterates through each slide and chart shape, disables
// the legend, and saves the modified presentation. This pattern can be used
// to automate PPTX workflows, customize chart appearances, or integrate
// presentation processing into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Chart, Legend,
// Presentation, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate removal of chart legends from presentations.
// - Build C# tools for PowerPoint presentation customization.
// - Generate or transform PPTX files in .NET applications.
// - Validate and preprocess presentation content before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace RemoveChartLegends
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Check if the shape is a chart
                            if (shape is IChart)
                            {
                                IChart chart = (IChart)shape;

                                // Remove the legend by disabling it
                                chart.HasLegend = false;
                            }
                        }
                    }

                    // Save the modified presentation
                    string outputPath = "output.pptx";
                    pres.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved successfully: " + outputPath);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
