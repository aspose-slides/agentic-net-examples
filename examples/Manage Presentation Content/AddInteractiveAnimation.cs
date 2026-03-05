using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using System.Drawing;

namespace InteractiveAnimationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a rectangle shape and set its text
            Aspose.Slides.IAutoShape rect = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                50,   // X position
                150,  // Y position
                300,  // Width
                100   // Height
            );
            rect.AddTextFrame("Animated Shape");

            // Add a PathFootball animation that starts after the previous effect
            slide.Timeline.MainSequence.AddEffect(
                rect,
                Aspose.Slides.Animation.EffectType.PathFootball,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious
            );

            // Add a button shape (Bevel) that will trigger the interactive animation
            Aspose.Slides.IShape button = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Bevel,
                400, // X position
                150, // Y position
                100, // Width
                50   // Height
            );

            // Create an interactive sequence linked to the button shape
            Aspose.Slides.Animation.ISequence interactiveSeq = slide.Timeline.InteractiveSequences.Add(button);

            // Add a PathUser motion effect to the rectangle, triggered on click of the button
            Aspose.Slides.Animation.IEffect motionEffect = interactiveSeq.AddEffect(
                rect,
                Aspose.Slides.Animation.EffectType.PathUser,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.OnClick
            );

            // Retrieve the motion behavior from the effect
            Aspose.Slides.Animation.IMotionEffect motionBhv = (Aspose.Slides.Animation.IMotionEffect)motionEffect.Behaviors[0];

            // Define the first point of the motion path
            System.Drawing.PointF[] pts = new System.Drawing.PointF[1];
            pts[0] = new System.Drawing.PointF(0, 0);
            motionBhv.Path.Add(
                Aspose.Slides.Animation.MotionCommandPathType.LineTo,
                pts,
                Aspose.Slides.Animation.MotionPathPointsType.Auto,
                false
            );

            // Define the second point of the motion path
            pts[0] = new System.Drawing.PointF(100, 0);
            motionBhv.Path.Add(
                Aspose.Slides.Animation.MotionCommandPathType.LineTo,
                pts,
                Aspose.Slides.Animation.MotionPathPointsType.Auto,
                false
            );

            // End the motion path
            motionBhv.Path.Add(
                Aspose.Slides.Animation.MotionCommandPathType.End,
                null,
                Aspose.Slides.Animation.MotionPathPointsType.Auto,
                false
            );

            // Save the presentation
            pres.Save("InteractiveAnimation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}