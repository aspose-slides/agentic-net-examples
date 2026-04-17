using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideCloneExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Get the slide collection
                ISlideCollection slides = pres.Slides;

                // Find the index of the first slide that contains a chart
                int chartSlideIndex = -1;
                for (int i = 0; i < slides.Count; i++)
                {
                    ISlide slide = slides[i];
                    for (int j = 0; j < slide.Shapes.Count; j++)
                    {
                        Aspose.Slides.Charts.IChart chart = slide.Shapes[j] as Aspose.Slides.Charts.IChart;
                        if (chart != null)
                        {
                            chartSlideIndex = i;
                            break;
                        }
                    }
                    if (chartSlideIndex != -1)
                    {
                        break;
                    }
                }

                // If a chart slide was found, clone it after its position
                if (chartSlideIndex != -1)
                {
                    int insertIndex = chartSlideIndex + 1;
                    slides.InsertClone(insertIndex, slides[chartSlideIndex]);
                }
                else
                {
                    Console.WriteLine("No slide containing a chart was found.");
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);

                // Dispose the presentation
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other exceptions
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}