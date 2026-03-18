using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExtractChartAsImage
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input PPTX file path
                string inputPath = "input.pptx";
                // Output image file path
                string outputImagePath = "chart.png";

                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Assume the chart is on the first slide
                    ISlide slide = presentation.Slides[0];
                    IChart chart = null;

                    // Find the first chart shape on the slide
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is IChart)
                        {
                            chart = (IChart)shape;
                            break;
                        }
                    }

                    if (chart != null)
                    {
                        // Render the chart to an image
                        IImage chartImage = chart.GetImage();
                        // Save the chart image as PNG
                        chartImage.Save(outputImagePath, ImageFormat.Png);
                    }
                    else
                    {
                        Console.WriteLine("No chart found on the first slide.");
                    }

                    // Save the presentation before exiting
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}