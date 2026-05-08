using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string presentationPath = "input.pptx";
            string chartImagePath = "chart_high_res.png";

            // Verify that the presentation file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(presentationPath))
                {
                    // Access the first slide (adjust index as needed)
                    ISlide slide = pres.Slides[0];

                    // Find the first chart on the slide
                    IChart chart = null;
                    for (int i = 0; i < slide.Shapes.Count; i++)
                    {
                        IShape shape = slide.Shapes[i];
                        if (shape is IChart)
                        {
                            chart = (IChart)shape;
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
                        // Use ShapeThumbnailBounds.Shape and provide both scaleX and scaleY
                        IImage chartImage = chart.GetImage(ShapeThumbnailBounds.Shape, 3f, 3f);
                        chartImage.Save(chartImagePath, ImageFormat.Png);
                        Console.WriteLine("Chart image saved to: " + chartImagePath);
                    }

                    // Save the presentation before exiting (optional, can be a different file)
                    pres.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The requested file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors, loading errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}