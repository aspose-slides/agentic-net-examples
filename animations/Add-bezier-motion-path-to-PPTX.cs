using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Add a rectangle shape with text
        IAutoShape rect = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
        rect.AddTextFrame("Motion Path");

        // Add a motion path effect triggered on click
        IEffect motionEffect = pres.Slides[0].Timeline.MainSequence.AddEffect(
            rect,
            EffectType.PathUser,
            EffectSubtype.None,
            EffectTriggerType.OnClick);

        // Get the motion behavior from the effect
        IMotionEffect motionBhv = (IMotionEffect)motionEffect.Behaviors[0];

        // Define Bezier curve control points (relative coordinates)
        PointF[] pts = new PointF[3];
        pts[0] = new PointF(0, 0);          // start point
        pts[1] = new PointF(100, -150);    // first control point
        pts[2] = new PointF(200, 0);       // end point

        // Add a CurveTo command to the motion path using a smooth curve
        motionBhv.Path.Add(MotionCommandPathType.CurveTo, pts, MotionPathPointsType.CurveSmooth, false);

        // End the motion path
        motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

        // Save the presentation
        string outPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "MotionPathBezier.pptx");
        try
        {
            pres.Save(outPath, SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        pres.Dispose();
    }
}