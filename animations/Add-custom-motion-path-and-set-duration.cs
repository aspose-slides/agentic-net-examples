using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

        // Add a custom motion path effect to the shape
        Aspose.Slides.Animation.IEffect effect = slide.Timeline.MainSequence.AddEffect(
            shape,
            Aspose.Slides.Animation.EffectType.PathUser,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Set animation duration to three seconds (3000 milliseconds)
        effect.Timing.Duration = 3000;

        // Get the motion effect behavior from the effect
        Aspose.Slides.Animation.IMotionEffect motionEffect = (Aspose.Slides.Animation.IMotionEffect)effect.Behaviors[0];

        // Define a custom motion path (line to a point)
        System.Drawing.PointF[] points = new System.Drawing.PointF[1];
        points[0] = new System.Drawing.PointF(300, 0);
        motionEffect.Path.Add(
            Aspose.Slides.Animation.MotionCommandPathType.LineTo,
            points,
            Aspose.Slides.Animation.MotionPathPointsType.Auto,
            true);

        // Save the presentation
        string outPath = Path.Combine(Directory.GetCurrentDirectory(), "CustomMotionPath.pptx");
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}