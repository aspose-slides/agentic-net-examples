// -----------------------------------------------------------------------------
// Example: Adjust PPTX 3D ambient intensity using C#
//
// Description:
// Demonstrates how to increase the ambient lighting of 3‑D formatted shapes
// in a PowerPoint presentation using C# and Aspose.Slides for .NET. The
// example loads an existing PPTX file, modifies the LightRig settings of each
// shape that has 3‑D formatting to a brighter preset, and saves the result.
// This pattern can be used to programmatically enhance the visual appearance
// of 3‑D objects in presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D, Ambient Intensity, LightRig,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Increase ambient lighting of 3‑D shapes in bulk.
// - Build C# utilities for PowerPoint visual enhancements.
// - Automate PPTX transformations that involve 3‑D formatting.
// - Validate and adjust 3‑D lighting before publishing presentations.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Adjust3DLighting
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
                Presentation presentation = new Presentation(inputPath);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Check if the shape has 3D formatting
                        if (shape.ThreeDFormat != null)
                        {
                            // Increase ambient lighting by setting a brighter light rig preset
                            shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
                            shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // Format not supported.
            }
        }
    }
}
