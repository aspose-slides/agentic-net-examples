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
            string inputPath = "source.pptx";
            string outputPath = "cloned_chart_output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the source presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Assume the first slide contains the chart to clone
                    ISlide sourceSlide = pres.Slides[0];
                    IChart sourceChart = null;

                    // Find the first chart on the source slide
                    foreach (IShape shape in sourceSlide.Shapes)
                    {
                        if (shape is IChart)
                        {
                            sourceChart = (IChart)shape;
                            break;
                        }
                    }

                    if (sourceChart == null)
                    {
                        Console.WriteLine("No chart found on the first slide.");
                        return;
                    }

                    // Add a new empty slide to host the cloned chart
                    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
                    ISlide destSlide = pres.Slides.AddEmptySlide(layout);

                    // Clone the chart by creating a new chart with the same type and dimensions
                    IChart clonedChart = destSlide.Shapes.AddChart(
                        sourceChart.Type,
                        sourceChart.X,
                        sourceChart.Y,
                        sourceChart.Width,
                        sourceChart.Height);

                    // Copy basic properties (optional, extend as needed)
                    clonedChart.HasTitle = true;
                    clonedChart.ChartTitle.AddTextFrameForOverriding("Cloned Chart Title");

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors, Aspose.Slides specific errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}