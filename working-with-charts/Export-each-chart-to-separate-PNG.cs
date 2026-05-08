using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ExportChartsExample
{
    class Program
    {
        static void Main()
        {
            // Input presentation path
            string inputPath = "input.pptx";

            // Verify that the input file exists
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
                    int slideNumber = 0;

                    // Iterate through all slides
                    foreach (ISlide slide in pres.Slides)
                    {
                        slideNumber++;

                        int chartIndex = 0;

                        // Iterate through all shapes on the slide
                        foreach (IShape shape in slide.Shapes)
                        {
                            // Check if the shape is a chart
                            IChart chart = shape as IChart;
                            if (chart != null)
                            {
                                chartIndex++;

                                // Generate image of the chart
                                IImage chartImage = chart.GetImage();

                                // Build output file name
                                string outputFileName = string.Format("Chart_Slide{0}_Index{1}.png", slideNumber, chartIndex);

                                // Save the chart image as PNG
                                chartImage.Save(outputFileName, Aspose.Slides.ImageFormat.Png);
                            }
                        }
                    }

                    // Save the presentation before exiting (optional: save to a new file)
                    string outputPresentation = "output.pptx";
                    pres.Save(outputPresentation, SaveFormat.Pptx);
                }
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