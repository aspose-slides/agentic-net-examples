using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ExportCharts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path (can be passed as argument or hard‑coded)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Output directory for chart images
            string outputDir = "ChartImages";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Check if the shape is a chart
                        if (shape is IChart)
                        {
                            IChart chart = (IChart)shape;

                            // Get the chart image
                            IImage chartImage = chart.GetImage();

                            // Build a unique file name for the chart image
                            string imagePath = Path.Combine(outputDir,
                                $"slide_{slideIndex}_chart_{shapeIndex}.png");

                            // Save the chart image as PNG
                            chartImage.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                        }
                    }
                }

                // Save the (unchanged) presentation before exiting
                string outputPresentationPath = "output.pptx";
                presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            Console.WriteLine("Chart images exported successfully.");
        }
    }
}