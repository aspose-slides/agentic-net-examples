using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportChartsToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "charts.pdf";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the source presentation
                using (Presentation sourcePres = new Presentation(inputPath))
                {
                    // Create a new presentation to hold extracted charts
                    using (Presentation chartPres = new Presentation())
                    {
                        // Remove the default empty slide
                        if (chartPres.Slides.Count > 0)
                        {
                            chartPres.Slides.RemoveAt(0);
                        }

                        // Iterate through all slides in the source presentation
                        for (int slideIndex = 0; slideIndex < sourcePres.Slides.Count; slideIndex++)
                        {
                            ISlide sourceSlide = sourcePres.Slides[slideIndex];

                            // Iterate through all shapes in the current slide
                            for (int shapeIndex = 0; shapeIndex < sourceSlide.Shapes.Count; shapeIndex++)
                            {
                                Aspose.Slides.Charts.IChart sourceChart = sourceSlide.Shapes[shapeIndex] as Aspose.Slides.Charts.IChart;
                                if (sourceChart != null)
                                {
                                    // Add a new empty slide to the chart presentation
                                    ISlide newSlide = chartPres.Slides.AddEmptySlide(chartPres.LayoutSlides[0]);

                                    // Clone the chart onto the new slide
                                    newSlide.Shapes.AddClone(sourceChart);
                                }
                            }
                        }

                        // Save the chart presentation as a single PDF file
                        chartPres.Save(outputPath, SaveFormat.Pdf);
                    }
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The requested format is not supported for saving.
            }
            catch (Exception ex)
            {
                // Handle other potential exceptions (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}