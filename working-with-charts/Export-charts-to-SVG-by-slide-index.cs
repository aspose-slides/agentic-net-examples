using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation
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
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    ISlide slide = pres.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    foreach (IShape shape in slide.Shapes)
                    {
                        // Check if the shape is a chart
                        if (shape is IChart)
                        {
                            // Build the SVG file name using the slide index
                            string svgFileName = $"slide_{slideIndex}_chart.svg";

                            // Export each chart as a separate SVG
                            using (FileStream svgStream = new FileStream(svgFileName, FileMode.Create, FileAccess.Write))
                            {
                                // Create a temporary presentation containing only the chart shape
                                using (Presentation tempPres = new Presentation())
                                {
                                    // Add an empty slide to the temporary presentation
                                    ISlide tempSlide = tempPres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

                                    // Clone the chart shape onto the temporary slide
                                    tempSlide.Shapes.AddClone(shape);

                                    // Write the temporary slide (which now contains only the chart) as SVG
                                    tempSlide.WriteAsSvg(svgStream);
                                }
                            }
                        }
                    }
                }

                // Save the original presentation before exiting
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}