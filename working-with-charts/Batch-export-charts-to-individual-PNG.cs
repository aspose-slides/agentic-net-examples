using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchChartExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path (can be passed as first argument)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

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

                            // Export the chart as an image (preserves callout graphics)
                            Aspose.Slides.IImage chartImage = chart.GetImage();

                            // Build a unique file name for each chart
                            string chartImagePath = string.Format("chart_slide{0}_shape{1}.png", slideIndex + 1, shapeIndex + 1);

                            // Save the chart image as PNG
                            chartImage.Save(chartImagePath, Aspose.Slides.ImageFormat.Png);
                        }
                    }
                }

                // Save the (potentially modified) presentation before exiting
                string outputPath = "output.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs or web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}