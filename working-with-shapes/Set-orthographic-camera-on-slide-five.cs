// -----------------------------------------------------------------------------
// Example: Set orthographic camera on slide five using C#
//
// Description:
// Demonstrates how to set an orthographic front camera on all 3‑D shapes
// located on slide five of a PowerPoint presentation using Aspose.Slides for .NET.
// The example loads an existing PPTX file, updates the camera type for each
// shape that has a 3‑D format on the specified slide, and saves the result.
// This pattern can be used to automate PPTX workflows, validate 3‑D settings,
// or integrate presentation processing into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Orthographic, Camera, Slide,
// Five, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting an orthographic camera on slide five.
// - Build C# tools for PowerPoint 3‑D shape manipulation.
// - Generate or transform PPTX files with specific camera configurations.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);
            int slideIndex = 4; // Slide five (zero-based index)

            if (presentation.Slides.Count <= slideIndex)
            {
                Console.WriteLine("Slide five does not exist.");
                presentation.Dispose();
                return;
            }

            ISlide slide = presentation.Slides[slideIndex];
            foreach (IShape shape in slide.Shapes)
            {
                if (shape.ThreeDFormat != null)
                {
                    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
                }
            }

            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
