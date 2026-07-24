// -----------------------------------------------------------------------------
// Example: Add PPTX 3d circular motion path using C#
//
// Description:
// Demonstrates how to add a 3‑D circular motion path to a shape in a PPTX file 
// using C# and Aspose.Slides for .NET. The example creates a new presentation, 
// inserts a rectangle shape with 3‑D extrusion, builds a circular motion path 
// composed of eight line segments, applies the path as a motion animation, and 
// saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D, Circular Motion Path, Animation, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding 3‑D circular motion paths to PowerPoint slides.
// - Build C# utilities for enriching presentations with custom animations.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate and preview motion effects before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a rectangle shape and configure it as a 3D object
            IAutoShape shape = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
            shape.TextFrame.Text = "3D";
            shape.ThreeDFormat.Depth = 100;
            shape.ThreeDFormat.ExtrusionHeight = 100;

            // Add a motion path effect to the shape
            IAnimationTimeLine timeline = slide.Timeline;
            IEffect effect = timeline.MainSequence.AddEffect(
                shape,
                EffectType.PathUser,
                EffectSubtype.None,
                EffectTriggerType.AfterPrevious);

            // Get the motion effect behavior
            IMotionEffect motionEffect = (IMotionEffect)effect.Behaviors[0];

            // Create a circular motion path using multiple LineTo commands (8 points)
            MotionPath motionPath = new MotionPath();

            // Start from the current position
            motionPath.Add(MotionCommandPathType.MoveTo,
                new PointF[] { new PointF(0, 0) },
                MotionPathPointsType.Auto,
                true);

            // Define radius (as percent of shape size) and number of segments
            float radius = 50f;
            int segments = 8;
            double angleStep = Math.PI * 2 / segments;

            for (int i = 0; i < segments; i++)
            {
                float x = radius * (float)Math.Cos(i * angleStep);
                float y = radius * (float)Math.Sin(i * angleStep);
                motionPath.Add(MotionCommandPathType.LineTo,
                    new PointF[] { new PointF(x, y) },
                    MotionPathPointsType.Auto,
                    true);
            }

            // End the path
            motionPath.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, true);

            // Assign the constructed path to the motion effect
            motionEffect.Path = motionPath;

            // Save the presentation
            string outPath = Path.Combine(Directory.GetCurrentDirectory(), "3D_MotionPath.pptx");
            presentation.Save(outPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any exceptions (e.g., unsupported format, file I/O errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
