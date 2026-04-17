using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneShapeGradient
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

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
                    // Ensure there is at least one slide
                    if (pres.Slides.Count == 0)
                    {
                        Console.WriteLine("Presentation contains no slides.");
                        return;
                    }

                    // Get the first slide and its first shape
                    ISlide firstSlide = pres.Slides[0];
                    if (firstSlide.Shapes.Count == 0)
                    {
                        Console.WriteLine("First slide contains no shapes to clone.");
                        return;
                    }

                    IShape originalShape = firstSlide.Shapes[0];

                    // Ensure there is a second slide; add one if necessary
                    ISlide targetSlide;
                    if (pres.Slides.Count > 1)
                    {
                        targetSlide = pres.Slides[1];
                    }
                    else
                    {
                        targetSlide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
                    }

                    // Clone the shape onto the target slide
                    IShape clonedShape = targetSlide.Shapes.AddClone(originalShape);

                    // Change the fill of the cloned shape to a gradient
                    clonedShape.FillFormat.FillType = FillType.Gradient;
                    clonedShape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
                    // Example: set two gradient stops (optional)
                    clonedShape.FillFormat.GradientFormat.GradientStops.Clear();
                    clonedShape.FillFormat.GradientFormat.GradientStops.Add(0.0f, System.Drawing.Color.Blue);
                    clonedShape.FillFormat.GradientFormat.GradientStops.Add(1.0f, System.Drawing.Color.Green);

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}