using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

namespace AsposeSlidesSoftEdgeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Ensure the presentation has at least three slides (zero‑based index 2)
                    if (presentation.Slides.Count > 2)
                    {
                        // Access the third slide
                        Aspose.Slides.ISlide thirdSlide = presentation.Slides[2];

                        // Iterate through all shapes on the slide
                        Aspose.Slides.IShapeCollection shapes = thirdSlide.Shapes;
                        for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                        {
                            // Cast the shape to IChart if possible
                            Aspose.Slides.Charts.IChart chart = shapes[shapeIndex] as Aspose.Slides.Charts.IChart;
                            if (chart != null)
                            {
                                // Enable soft edge effect and set radius to 6 points
                                chart.EffectFormat.EnableSoftEdgeEffect();
                                chart.EffectFormat.SoftEdgeEffect.Radius = 6;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("The presentation does not contain a third slide.");
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}