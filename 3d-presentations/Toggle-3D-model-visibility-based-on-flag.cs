// -----------------------------------------------------------------------------
// Example: Toggle 3D Model Visibility on a PowerPoint Slide Using Aspose.Slides
//
// Description:
// This console application loads a PPTX file (if it exists) or creates a new
// presentation, scans the first slide for shapes that contain 3‑D formatting,
// and toggles their visibility based on a boolean flag. The result is saved
// as a new PPTX file. The code demonstrates Aspose.Slides for .NET usage,
// file existence checks, and basic exception handling.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D shape visibility, toggle, slide manipulation
//
// Use Cases:
// - Hide all 3‑D models in a presentation before sharing a draft.
// - Show 3‑D models only when a specific condition (e.g., user preference) is met.
// - Automate preparation of presentation assets for different audiences.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Flag that determines whether 3D models should be visible
        bool show3DModels = true; // Change to false to hide them

        // Ensure the output directory exists
        string outputDir = System.IO.Path.GetDirectoryName(System.IO.Path.GetFullPath(outputPath));
        if (!System.IO.Directory.Exists(outputDir))
        {
            System.IO.Directory.CreateDirectory(outputDir);
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            if (System.IO.File.Exists(inputPath))
            {
                // Load existing presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                // Create a new presentation if the input file does not exist
                presentation = new Aspose.Slides.Presentation();
                // Add a blank slide to work with
                Aspose.Slides.ISlide blankSlide = presentation.Slides[0];
                // Optionally add a sample 3D shape for demonstration
                Aspose.Slides.IAutoShape sampleShape = (Aspose.Slides.IAutoShape)blankSlide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Ellipse, 100, 100, 200, 200);
                // Enable a simple 3D effect
                sampleShape.ThreeDFormat.Depth = 4;
                sampleShape.ThreeDFormat.BevelTop.BevelType = Aspose.Slides.BevelPresetType.Circle;
                sampleShape.ThreeDFormat.BevelTop.Height = 2;
                sampleShape.ThreeDFormat.BevelTop.Width = 2;
            }

            // Process the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            for (int i = 0; i < slide.Shapes.Count; i++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[i];
                // Check if the shape has a ThreeDFormat (i.e., is a 3D model)
                if (shape.ThreeDFormat != null)
                {
                    // Toggle visibility using the Hidden property
                    shape.Hidden = !show3DModels;
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            // Write exception details to console
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        finally
        {
            // Ensure resources are released
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}
