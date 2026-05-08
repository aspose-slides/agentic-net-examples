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
            // Input presentation path
            string inputPath = "input.pptx";
            // Output image path
            string outputImagePath = "chart_highres.png";

            try
            {
                // Check if the input file exists
                if (File.Exists(inputPath))
                {
                    // Load existing presentation
                    using (Presentation pres = new Presentation(inputPath))
                    {
                        // Find the first chart in the first slide
                        ISlide slide = pres.Slides[0];
                        IChart chart = null;
                        foreach (IShape shape in slide.Shapes)
                        {
                            chart = shape as IChart;
                            if (chart != null)
                            {
                                break;
                            }
                        }

                        if (chart != null)
                        {
                            // High‑resolution scaling factors
                            float scaleX = 2f;
                            float scaleY = 2f;

                            // Get chart image with required bounds and scaling
                            IImage chartImage = chart.GetImage(ShapeThumbnailBounds.Shape, scaleX, scaleY);

                            // Save the image as PNG
                            chartImage.Save(outputImagePath, ImageFormat.Png);
                        }
                        else
                        {
                            // No chart found; optionally handle this case
                            Console.WriteLine("No chart found in the presentation.");
                        }

                        // Save the presentation before exiting (if any modifications were made)
                        pres.Save("output.pptx", SaveFormat.Pptx);
                    }
                }
                else
                {
                    // Create a new presentation and add a sample chart
                    using (Presentation pres = new Presentation())
                    {
                        ISlide slide = pres.Slides[0];
                        // Add a clustered column chart
                        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                        // High‑resolution scaling factors
                        float scaleX = 2f;
                        float scaleY = 2f;

                        // Export the newly added chart as PNG
                        IImage chartImage = chart.GetImage(ShapeThumbnailBounds.Shape, scaleX, scaleY);
                        chartImage.Save(outputImagePath, ImageFormat.Png);

                        // Save the newly created presentation
                        pres.Save("new_presentation.pptx", SaveFormat.Pptx);
                    }
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported – handle accordingly
                Console.WriteLine("The requested file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors, Aspose.Slides errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}