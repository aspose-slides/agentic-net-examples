// -----------------------------------------------------------------------------
// Example: Apply 45° Y‑Axis Rotation to All 3D Shapes in a PowerPoint Presentation
//
// Description:
// This console application loads an existing PPTX file, iterates through every
// slide and shape, and applies a 45‑degree rotation around the Y‑axis to each
// shape that has a 3‑D format. It uses Aspose.Slides for .NET to modify the
// presentation and saves the result as a new PPTX file. The task demonstrates
// how to work with 3‑D camera rotation in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D rotation, Y‑axis, shape transformation
//
// Use Cases:
// - Standardize 3‑D orientation across all slides in a corporate deck.
// - Prepare a presentation for consistent visual effects before publishing.
// - Batch‑process existing PPTX files to apply a uniform 3‑D rotation.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesRotationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "input.pptx";
            string outputFile = "output_rotated.pptx";

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file not found: " + inputFile);
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile);

                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape.ThreeDFormat != null)
                        {
                            // Apply 45-degree rotation around the Y‑axis
                            shape.ThreeDFormat.Camera.SetRotation(0, 45, 0);
                        }
                    }
                }

                // Ensure output directory exists
                string outputDir = Path.GetDirectoryName(Path.GetFullPath(outputFile));
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved successfully to: " + outputFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
