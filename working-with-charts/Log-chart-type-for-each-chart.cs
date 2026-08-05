// -----------------------------------------------------------------------------
// Example: Log chart type for each chart using C#
//
// Description:
// Demonstrates how to iterate through all slides and shapes in a PowerPoint
// presentation, identify chart objects, and log each chart's type to the console
// using Aspose.Slides for .NET. The example also shows how to load a presentation,
// optionally save it, and handle basic file‑existence and error scenarios.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Chart, ChartType, Logging, Presentation Processing
//
// Use Cases:
// - Audit or report chart types used in existing presentations.
// - Build tools that validate or document slide content.
// - Automate extraction of chart metadata for further analysis.
// - Integrate chart‑type logging into larger .NET PowerPoint automation workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesChartLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "input.pptx";

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: The file '" + inputPath + "' does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Check if the shape is a chart
                            if (shape is IChart)
                            {
                                IChart chart = (IChart)shape;
                                ChartType chartType = chart.Type;

                                // Log the chart type
                                Console.WriteLine("Slide " + (slideIndex + 1) + ", Shape " + (shapeIndex + 1) + ": Chart type = " + chartType);
                            }
                        }
                    }

                    // Save the presentation (even if unchanged) before exiting
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Note: Aspose.Slides.SlidesException does not exist; using generic Exception
                Console.WriteLine("An error occurred: " + ex.Message);
                // If the format is not supported, you may add specific handling here
            }
        }
    }
}
