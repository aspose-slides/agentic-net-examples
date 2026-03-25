using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace RemoveChartDataPoints
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
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                ISlide slide = pres.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = slide.Shapes[shapeIndex];

                    // Process only chart shapes
                    IChart chart = shape as IChart;
                    if (chart != null && chart.ChartData.Series.Count > 0)
                    {
                        // Example: remove the first data point from the first series
                        try
                        {
                            chart.ChartData.Series[0].DataPoints.RemoveAt(0);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Failed to remove data point: " + ex.Message);
                        }
                    }
                }
            }

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}