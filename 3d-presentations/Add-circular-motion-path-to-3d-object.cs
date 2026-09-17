// -----------------------------------------------------------------------------
// Example: Add Circular Motion Path Animation to a 3D Shape in PowerPoint
//
// Description:
// This console application creates a new PPTX file, adds a rectangular shape
// with 3‑D formatting, and applies a custom circular motion path animation
// using Aspose.Slides for .NET. The output is a PowerPoint presentation that
// demonstrates a 3‑D object moving along a circular trajectory.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D shape, motion path, circular animation
//
// Use Cases:
// - Generating animated slide decks with 3‑D objects for marketing presentations.
// - Automating creation of instructional videos where objects follow a path.
// - Building interactive e‑learning content with custom motion animations.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Define output file path
        string outputPath = "Output/3DShapeCircularMotion.pptx";
        string outputDirectory = Path.GetDirectoryName(Path.GetFullPath(outputPath));
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangular shape that will act as a 3D object
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                100,   // X position
                100,   // Y position
                100,   // Width
                100);  // Height

            // Apply simple 3D formatting
            shape.ThreeDFormat.Depth = 5;
            shape.ThreeDFormat.ExtrusionColor.Color = Color.Gray;

            // Add a text frame to identify the shape (use IAutoShape, not IShape)
            shape.AddTextFrame("3D Object");

            // Add a custom motion path effect (PathUser) to the shape
            Aspose.Slides.Animation.IEffect effect = slide.Timeline.MainSequence.AddEffect(
                shape,
                Aspose.Slides.Animation.EffectType.PathUser,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Retrieve the motion behavior from the effect
            Aspose.Slides.Animation.IMotionEffect motionEffect = (Aspose.Slides.Animation.IMotionEffect)effect.Behaviors[0];

            // Define points for a simple circular trajectory (approximated with four line segments)
            // Center of the circle will be at (150,150) with radius 50
            System.Drawing.PointF[] pts = new System.Drawing.PointF[1];

            // Move to the rightmost point
            pts[0] = new System.Drawing.PointF(200, 150);
            motionEffect.Path.Add(
                Aspose.Slides.Animation.MotionCommandPathType.LineTo,
                pts,
                Aspose.Slides.Animation.MotionPathPointsType.Auto,
                false);

            // Move to the bottom point
            pts[0] = new System.Drawing.PointF(150, 200);
            motionEffect.Path.Add(
                Aspose.Slides.Animation.MotionCommandPathType.LineTo,
                pts,
                Aspose.Slides.Animation.MotionPathPointsType.Auto,
                false);

            // Move to the leftmost point
            pts[0] = new System.Drawing.PointF(100, 150);
            motionEffect.Path.Add(
                Aspose.Slides.Animation.MotionCommandPathType.LineTo,
                pts,
                Aspose.Slides.Animation.MotionPathPointsType.Auto,
                false);

            // Move back to the top point (starting position)
            pts[0] = new System.Drawing.PointF(150, 100);
            motionEffect.Path.Add(
                Aspose.Slides.Animation.MotionCommandPathType.LineTo,
                pts,
                Aspose.Slides.Animation.MotionPathPointsType.Auto,
                false);

            // End the motion path
            motionEffect.Path.Add(
                Aspose.Slides.Animation.MotionCommandPathType.End,
                null,
                Aspose.Slides.Animation.MotionPathPointsType.Auto,
                false);

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();

            Console.WriteLine("Presentation saved successfully to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
