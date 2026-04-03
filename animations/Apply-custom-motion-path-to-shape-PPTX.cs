using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var pres = new Presentation();

        // Get the first slide
        var slide = pres.Slides[0];

        // Add a rectangle shape
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

        // Add a custom motion path effect to the shape
        var effect = slide.Timeline.MainSequence.AddEffect(
            shape,
            EffectType.PathUser,
            EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

        // Set animation duration to 3 seconds (assuming seconds)
        effect.Timing.Duration = 3.0f;

        // Get the motion effect behavior
        var motionEffect = (IMotionEffect)effect.Behaviors[0];

        // Define points for the custom motion path
        PointF[] pts = new PointF[1];

        // Move to start point (0,0)
        pts[0] = new PointF(0, 0);
        motionEffect.Path.Add(MotionCommandPathType.MoveTo, pts, MotionPathPointsType.Auto, true);

        // Line to (100,0)
        pts[0] = new PointF(100, 0);
        motionEffect.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);

        // Line to (100,100)
        pts[0] = new PointF(100, 100);
        motionEffect.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);

        // Line to (0,100)
        pts[0] = new PointF(0, 100);
        motionEffect.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);

        // End of path
        motionEffect.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, true);

        // Save the presentation
        string outPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "CustomMotionPath.pptx");
        pres.Save(outPath, SaveFormat.Pptx);
        pres.Dispose();
    }
}