using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace RetrieveChartAxisMaxValue
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Error: Input file \"{inputPath}\" not found.");
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    ISlide slide = pres.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        // Check if the shape is a chart
                        if (slide.Shapes[shapeIndex] is IChart)
                        {
                            IChart chart = (IChart)slide.Shapes[shapeIndex];

                            // Ensure layout is validated to get actual axis values
                            chart.ValidateChartLayout();

                            // Retrieve the actual maximum value of the vertical axis
                            double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;

                            Console.WriteLine($"Slide {slideIndex + 1}, Chart {shapeIndex + 1}: Vertical Axis Max Value = {maxValue}");
                        }
                    }
                }

                // Save the (potentially unchanged) presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}