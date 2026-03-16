using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Rotate3DShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the source presentation
                string inputPath = "input.pptx";
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through each slide
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];
                        // Iterate through each shape on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];
                            // Apply 3D rotation if the shape supports ThreeDFormat
                            if (shape.ThreeDFormat != null)
                            {
                                // Rotate around X, Y, Z axes (degrees)
                                shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
                                // Example: set depth of the 3D effect
                                shape.ThreeDFormat.Depth = 50;
                            }
                        }
                    }

                    // Save the modified presentation
                    string outputPath = "output.pptx";
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}