using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Ensure the third slide exists (zero‑based index)
                if (presentation.Slides.Count > 2)
                {
                    Aspose.Slides.ISlide thirdSlide = presentation.Slides[2];

                    // Iterate through all shapes on the third slide
                    for (int shapeIndex = 0; shapeIndex < thirdSlide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = thirdSlide.Shapes[shapeIndex];

                        // Apply soft edge only to chart shapes
                        Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                        if (chart != null)
                        {
                            // Enable soft edge effect
                            chart.EffectFormat.EnableSoftEdgeEffect();

                            // Set the soft edge radius to six points
                            chart.EffectFormat.SoftEdgeEffect.Radius = 6.0;
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
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