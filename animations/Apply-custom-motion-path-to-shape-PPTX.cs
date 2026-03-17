using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Presentation presentation = new Presentation(inputPath))
            {
                ISlide slide = presentation.Slides[0];
                IShape shape = slide.Shapes[0];

                // Add a custom effect placeholder
                IEffect effect = slide.Timeline.MainSequence.AddEffect(
                    shape,
                    EffectType.Custom,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Create a motion effect behavior
                BehaviorFactory behaviorFactory = new BehaviorFactory();
                IMotionEffect motionEffect = behaviorFactory.CreateMotionEffect();

                // Define a simple rectangular motion path
                MotionPath motionPath = new MotionPath();
                motionPath.Add(
                    MotionCommandPathType.MoveTo,
                    new PointF[] { new PointF(0, 0) },
                    MotionPathPointsType.Auto,
                    true);
                motionPath.Add(
                    MotionCommandPathType.LineTo,
                    new PointF[] { new PointF(50, 0) },
                    MotionPathPointsType.Auto,
                    true);
                motionPath.Add(
                    MotionCommandPathType.LineTo,
                    new PointF[] { new PointF(50, 50) },
                    MotionPathPointsType.Auto,
                    true);
                motionPath.Add(
                    MotionCommandPathType.LineTo,
                    new PointF[] { new PointF(0, 0) },
                    MotionPathPointsType.Auto,
                    true);
                motionPath.Add(
                    MotionCommandPathType.End,
                    null,
                    MotionPathPointsType.Auto,
                    true);

                // Assign the path to the motion effect
                motionEffect.Path = motionPath;
                motionEffect.PathEditMode = MotionPathEditMode.Relative;

                // Attach the motion behavior to the effect
                effect.Behaviors.Add(motionEffect);

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}