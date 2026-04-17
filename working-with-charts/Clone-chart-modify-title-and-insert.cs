using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace CloneChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = "source.pptx";
            string outputPath = "output.pptx";

            // Verify source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source presentation file not found: " + sourcePath);
                return;
            }

            try
            {
                // Load the source presentation
                using (Presentation pres = new Presentation(sourcePath))
                {
                    // Get the first slide (assumed to contain the chart to clone)
                    ISlide sourceSlide = pres.Slides[0];

                    // Retrieve the first chart on the source slide
                    IChart sourceChart = sourceSlide.Shapes[0] as IChart;
                    if (sourceChart == null)
                    {
                        Console.WriteLine("No chart found on the first slide.");
                        return;
                    }

                    // Ensure there is a target slide to place the cloned chart
                    ISlide targetSlide;
                    if (pres.Slides.Count > 1)
                    {
                        targetSlide = pres.Slides[1];
                    }
                    else
                    {
                        // Add an empty slide using the first layout slide as a template
                        targetSlide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
                    }

                    // Add a new chart on the target slide with the same type and size as the source chart
                    IChart clonedChart = targetSlide.Shapes.AddChart(
                        sourceChart.Type,
                        sourceChart.X,
                        sourceChart.Y,
                        sourceChart.Width,
                        sourceChart.Height);

                    // Copy the chart title (modify as needed)
                    clonedChart.HasTitle = true;
                    clonedChart.ChartTitle.AddTextFrameForOverriding("Cloned Chart Title");

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // If the format is not supported, Aspose.Slides may throw a specific exception.
                // Comment: format not supported.
            }
        }
    }
}