// -----------------------------------------------------------------------------
// Example: Apply Bevel Effect to 3D Shape in PowerPoint using Aspose.Slides
//
// Description:
// This console application creates a new PowerPoint presentation, adds an
// ellipse shape, and applies a 3‑D bevel effect to enhance visual depth.
// It demonstrates the use of Aspose.Slides for .NET APIs such as BevelPresetType,
// CameraPresetType, LightRigPresetType, and SaveFormat.Pptx. The resulting PPTX
// file is saved to the local file system.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, bevel effect, 3D shape, graphics
//
// Use Cases:
// - Adding decorative 3‑D effects to shapes in automated slide generation.
// - Enhancing visual hierarchy in marketing presentations programmatically.
// - Generating PPTX files with custom styling for reporting tools.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

namespace BevelEffectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "BevelEffectDemo.pptx";

            try
            {
                // Ensure output directory exists
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(outputDir) && !Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add an ellipse shape
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Ellipse,
                    100,   // X position
                    100,   // Y position
                    300,   // Width
                    200    // Height
                );

                // Set solid fill color
                shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

                // Set line format
                shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
                shape.LineFormat.Width = 2.0;

                // Apply 3‑D bevel effect
                Aspose.Slides.IThreeDFormat threeD = shape.ThreeDFormat;
                threeD.Depth = 5;
                threeD.BevelTop.BevelType = Aspose.Slides.BevelPresetType.Circle;
                threeD.BevelTop.Height = 5;
                threeD.BevelTop.Width = 5;
                threeD.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
                threeD.LightRig.LightType = Aspose.Slides.LightRigPresetType.ThreePt;
                threeD.LightRig.Direction = Aspose.Slides.LightingDirection.Top;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + Path.GetFullPath(outputPath));
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
