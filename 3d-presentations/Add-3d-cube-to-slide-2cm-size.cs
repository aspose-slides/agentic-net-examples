// -----------------------------------------------------------------------------
// Example: Add 3D Cube Shape to Slide and Set Size to 2 cm
//
// Description:
// This console application demonstrates how to load or create a PowerPoint
// presentation, add a 3D cube shape to a specific slide, set its dimensions to
// 2 centimeters, and save the result as a PPTX file using Aspose.Slides for .NET.
// The task involves handling file existence checks and proper float literals
// for size parameters.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D cube, shape size, slide manipulation
//
// Use Cases:
// - Programmatically enrich presentations with 3D graphics for marketing decks.
// - Automate slide design by adding standardized 3D objects at runtime.
// - Ensure consistent shape dimensions across generated slides in reporting tools.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesCubeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Ensure the input file exists; otherwise create a new presentation
            Aspose.Slides.Presentation presentation;
            if (File.Exists(inputPath))
            {
                try
                {
                    presentation = new Aspose.Slides.Presentation(inputPath);
                }
                catch (Exception ex)
                {
                    // If the file format is not supported, create a new presentation
                    // Format not supported.
                    presentation = new Aspose.Slides.Presentation();
                }
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }

            // Choose the target slide (first slide; add one if none exist)
            Aspose.Slides.ISlide targetSlide;
            if (presentation.Slides.Count > 0)
            {
                targetSlide = presentation.Slides[0];
            }
            else
            {
                targetSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            }

            // Convert 2 centimeters to points (1 cm ≈ 28.3464567 points)
            float sizeInPoints = 2.0F * 28.3464567F; // ≈56.6929134 points

            // Add a 3D cube shape at position (0,0) with the calculated size
            try
            {
                Aspose.Slides.IShape cubeShape = targetSlide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Cube,
                    0F,
                    0F,
                    sizeInPoints,
                    sizeInPoints);
            }
            catch (Exception ex)
            {
                // Handle any errors related to adding the shape (e.g., unsupported shape type)
                Console.WriteLine("Error adding 3D cube shape: " + ex.Message);
            }

            // Save the presentation
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., permission issues)
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}
