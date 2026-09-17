// -----------------------------------------------------------------------------
// Example: Apply Bevel Effect to 3D Shape in PowerPoint using Aspose.Slides
//
// Description:
// This console application creates a new PowerPoint presentation, adds an
// ellipse shape, and applies a 3‑D bevel effect to enhance visual depth.
// It demonstrates using Aspose.Slides for .NET to set fill, line, camera,
// lighting, and bevel properties, then saves the file as PPTX.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, bevel effect, 3D shape, visual depth
//
// Use Cases:
// - Generate marketing slides with highlighted 3‑D objects.
// - Automate design of presentation templates with consistent bevel styling.
// - Enhance data visualizations by adding depth to chart elements.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "BevelEffectDemo.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an ellipse shape
        Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Ellipse, 100, 100, 300, 200);

        // Set solid fill color
        shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

        // Set line format
        shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
        shape.LineFormat.Width = 2.0;

        // Apply 3‑D bevel effect
        shape.ThreeDFormat.Depth = 3;
        shape.ThreeDFormat.BevelTop.BevelType = Aspose.Slides.BevelPresetType.Circle;
        shape.ThreeDFormat.BevelTop.Height = 5;
        shape.ThreeDFormat.BevelTop.Width = 5;
        shape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
        shape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.ThreePt;
        shape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;

        // Save the presentation
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            Console.WriteLine("Presentation saved to " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during saving (e.g., unsupported format)
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            // Ensure resources are released
            presentation.Dispose();
        }
    }
}
