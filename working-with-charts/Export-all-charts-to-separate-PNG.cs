using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExportChartsToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect the first argument to be the path of the presentation file.
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the path to the presentation file as an argument.");
                return;
            }

            string inputPath = args[0];

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"File not found: {inputPath}");
                return;
            }

            try
            {
                // Load the presentation.
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides.
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];

                        // Iterate through all shapes on the slide.
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Check if the shape is a chart.
                            IChart chart = shape as IChart;
                            if (chart != null)
                            {
                                // Generate a file name using slide and shape indexes.
                                string chartFileName = $"chart_slide{slideIndex + 1}_shape{shapeIndex + 1}.png";

                                // Export the chart as a PNG image.
                                chart.GetImage().Save(chartFileName, Aspose.Slides.ImageFormat.Png);
                                Console.WriteLine($"Exported chart to {chartFileName}");
                            }
                        }
                    }

                    // Save the (unchanged) presentation before exiting.
                    string outputPath = "output.pptx";
                    pres.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine($"Presentation saved as {outputPath}");
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported.
                // Comment: The presentation format is not supported for the requested operation.
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other unexpected exceptions (e.g., network issues if URLs were used).
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}