using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExportAnimatedChart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPresentationPath = "input.pptx";
            string outputChartImagePath = "chart.png";
            string outputPresentationPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPresentationPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPresentationPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPresentationPath);

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Find the first chart on the slide
                Aspose.Slides.Charts.IChart chart = null;
                for (int i = 0; i < slide.Shapes.Count; i++)
                {
                    if (slide.Shapes[i] is Aspose.Slides.Charts.IChart)
                    {
                        chart = (Aspose.Slides.Charts.IChart)slide.Shapes[i];
                        break;
                    }
                }

                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                }
                else
                {
                    // Export the chart as a high‑resolution PNG image
                    // Using ShapeThumbnailBounds.Shape with scaling factors for high resolution
                    Aspose.Slides.IImage chartImage = chart.GetImage(ShapeThumbnailBounds.Shape, 2f, 2f);
                    chartImage.Save(outputChartImagePath, Aspose.Slides.ImageFormat.Png);
                }

                // Save the (potentially modified) presentation
                presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
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