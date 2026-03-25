using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace DisableHorizontalAxis
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path (first argument or default)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            // Output PPTX file path
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
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
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                        // Check if the shape is a chart
                        Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                        if (chart != null)
                        {
                            // Process only line charts (Line or LineWithMarkers)
                            if (chart.Type == Aspose.Slides.Charts.ChartType.Line ||
                                chart.Type == Aspose.Slides.Charts.ChartType.LineWithMarkers)
                            {
                                // Disable the horizontal axis
                                chart.Axes.HorizontalAxis.IsVisible = false;
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            Console.WriteLine("Presentation saved to " + outputPath);
        }
    }
}