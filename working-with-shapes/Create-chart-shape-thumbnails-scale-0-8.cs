using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartThumbnailGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output folder for thumbnails
            string outputDir = "ChartThumbnails";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            // Attempt to cast the shape to a chart
                            IChart chart = slide.Shapes[shapeIndex] as IChart;
                            if (chart != null)
                            {
                                // Generate thumbnail with 0.8 scaling factor
                                IImage chartImage = chart.GetImage(ShapeThumbnailBounds.Shape, 0.8f, 0.8f);

                                // Build thumbnail file name
                                string chartFileName = Path.Combine(outputDir,
                                    $"Slide_{slide.SlideNumber}_Chart_{shapeIndex}.png");

                                // Save the thumbnail as PNG
                                chartImage.Save(chartFileName, Aspose.Slides.ImageFormat.Png);
                            }
                        }
                    }

                    // Save the presentation (no changes made, but required by lifecycle rule)
                    pres.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs, web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}