using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Validate3DShapeNames
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_validated.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Load the presentation
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // Format not supported
                return;
            }

            // Iterate through all slides and shapes
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = slide.Shapes[shapeIndex];

                    // Check if the shape has 3‑D formatting
                    if (shape.ThreeDFormat != null)
                    {
                        // Validate that the shape name is not empty
                        if (string.IsNullOrEmpty(shape.Name))
                        {
                            Console.WriteLine($"3D shape on slide {slideIndex + 1}, index {shapeIndex} has an empty name. Assigning a default name.");
                            shape.Name = $"3DShape_{slideIndex + 1}_{shapeIndex}";
                        }
                    }
                }
            }

            // Save the presentation before exiting
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}