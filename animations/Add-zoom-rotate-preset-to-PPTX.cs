using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "CustomZoomRotate.pptx");
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to animate
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
            shape.Rotation = 0; // Initial rotation

            // Add a zoom effect triggered on click
            Aspose.Slides.Animation.IEffect zoomEffect = slide.Timeline.MainSequence.AddEffect(
                shape,
                EffectType.FadedZoom,
                EffectSubtype.ObjectCenter,
                EffectTriggerType.OnClick);

            // Add a rotate effect after the zoom
            Aspose.Slides.Animation.ISequence interactiveSeq = slide.Timeline.InteractiveSequences.Add(shape);
            Aspose.Slides.Animation.IEffect rotateEffect = interactiveSeq.AddEffect(
                shape,
                EffectType.PathUser,
                EffectSubtype.None,
                EffectTriggerType.AfterPrevious);

            // Define a simple motion path (required by the API)
            Aspose.Slides.Animation.IMotionEffect motion = (Aspose.Slides.Animation.IMotionEffect)rotateEffect.Behaviors[0];
            PointF[] points = new PointF[1];
            points[0] = new PointF(0, 0);
            motion.Path.Add(MotionCommandPathType.End, points, MotionPathPointsType.Auto, false);

            // Apply rotation to the shape (final state after animation)
            shape.Rotation = 45;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}