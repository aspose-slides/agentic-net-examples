// -----------------------------------------------------------------------------
// Example: Apply 45° Y-Axis Rotation to All 3D Shapes in a PowerPoint Presentation
//
// Description:
// This console application loads an existing PPTX file, iterates through every
// slide and shape, and applies a 45‑degree rotation around the Y‑axis to each
// shape that has a 3‑D format. It uses Aspose.Slides for .NET to modify the
// presentation and saves the result as a new PPTX file. The task demonstrates
// handling of 3‑D shape transformations in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D rotation, shape transformation, camera rotation
//
// Use Cases:
// - Adjusting the visual perspective of 3‑D objects in a corporate slide deck.
// - Programmatically enhancing presentations with consistent 3‑D orientation.
// - Automating bulk updates of 3‑D shape rotations across multiple slides.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = args.Length > 0 ? args[0] : "input.pptx";
        string outputPath = args.Length > 1 ? args[1] : "output_rotated.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape.ThreeDFormat != null)
                    {
                        // Rotate 45 degrees around the Y‑axis (X and Z remain unchanged)
                        shape.ThreeDFormat.Camera.SetRotation(0, 45, 0);
                    }
                }
            }

            string outputDirectory = Path.GetDirectoryName(Path.GetFullPath(outputPath));
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();

            Console.WriteLine("Presentation saved with rotated 3D shapes: " + outputPath);
        }
        catch (NotSupportedException ex)
        {
            Console.WriteLine("The file format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while processing the presentation: " + ex.Message);
        }
    }
}
