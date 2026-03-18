using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RotateAndFlipShape
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Input and output file paths
                var inputPath = "input.pptx";
                var outputPath = "output.pptx";

                // Load the presentation
                using (var presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Get the first slide
                    var slide = presentation.Slides[0];

                    // Get the first shape on the slide (replace with your target shape as needed)
                    var shape = slide.Shapes[0];

                    // Rotate the shape by 45 degrees
                    shape.Rotation = 45f;

                    // Apply horizontal flip by creating a new ShapeFrame with FlipH = true
                    shape.Frame = new Aspose.Slides.ShapeFrame(
                        shape.X,
                        shape.Y,
                        shape.Width,
                        shape.Height,
                        Aspose.Slides.NullableBool.True,   // Flip horizontally
                        Aspose.Slides.NullableBool.False,  // No vertical flip
                        shape.Rotation);

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}