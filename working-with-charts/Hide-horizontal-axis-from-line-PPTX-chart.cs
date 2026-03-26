using System;
using System.IO;
using Aspose.Slides.Export;

namespace DisableHorizontalAxis
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
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        // Check if the shape is a chart
                        if (slide.Shapes[shapeIndex] is Aspose.Slides.Charts.IChart)
                        {
                            Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)slide.Shapes[shapeIndex];

                            // Process only line charts
                            if (chart.Type == Aspose.Slides.Charts.ChartType.Line)
                            {
                                // Disable (hide) the horizontal axis
                                chart.Axes.HorizontalAxis.IsVisible = false;
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}