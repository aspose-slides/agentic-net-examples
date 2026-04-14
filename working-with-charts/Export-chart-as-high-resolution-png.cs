using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExportChartHighResPng
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string chartImagePath = "chart_high_res.png";
            string outputPresentationPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Find the first chart in the first slide
                    IChart chart = null;
                    ISlide slide = pres.Slides[0];
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is IChart)
                        {
                            chart = (IChart)shape;
                            break;
                        }
                    }

                    if (chart == null)
                    {
                        Console.WriteLine("No chart found in the presentation.");
                    }
                    else
                    {
                        // Export the chart as a high‑resolution PNG (scale factor 2x)
                        IImage chartImage = chart.GetImage(ShapeThumbnailBounds.Shape, 2f, 2f);
                        chartImage.Save(chartImagePath, ImageFormat.Png);
                        chartImage.Dispose();
                        Console.WriteLine("Chart exported to: " + chartImagePath);
                    }

                    // Save the presentation (as required by lifecycle rules)
                    pres.Save(outputPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}