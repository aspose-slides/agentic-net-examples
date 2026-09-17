// -----------------------------------------------------------------------------
// Example: Validate 3D Shape Names in PowerPoint Presentation
//
// Description:
// This console application loads a PPTX file using Aspose.Slides for .NET,
// iterates through all slides and shapes, and verifies that every 3D shape
// has a non‑empty Name property. It reports missing names and saves the
// presentation after validation. The task involves PowerPoint, PPTX, and
// Aspose.Slides APIs.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D shape validation, shape name check
//
// Use Cases:
// - Ensure 3D objects in a corporate deck are properly labeled for accessibility.
// - Automate quality checks before publishing presentations to a portal.
// - Detect unnamed 3D shapes that could cause confusion during slide navigation.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlides3DNameValidator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: File not found - " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Error: Unsupported PPTX format. " + ex.Message);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                    // A shape is considered 3D if its ThreeDFormat property is not null.
                    if (shape.ThreeDFormat != null)
                    {
                        if (string.IsNullOrWhiteSpace(shape.Name))
                        {
                            Console.WriteLine($"Warning: 3D shape at Slide {slideIndex + 1}, Shape {shapeIndex + 1} has an empty Name.");
                        }
                    }
                }
            }

            try
            {
                string outputPath = "validated_output.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}
