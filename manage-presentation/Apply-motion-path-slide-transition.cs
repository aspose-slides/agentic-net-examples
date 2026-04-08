using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace ApplyMotionPathSlideTransition
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a rectangle shape to the slide
                    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
                    shape.TextFrame.Text = "Motion Path";

                    // Add a Fly entrance effect to the shape
                    IEffect effect = slide.Timeline.MainSequence.AddEffect(
                        shape,
                        EffectType.Fly,
                        EffectSubtype.Left,
                        EffectTriggerType.AfterPrevious);

                    // Create a motion effect behavior using an instance of BehaviorFactory
                    BehaviorFactory behaviorFactory = new BehaviorFactory();
                    IMotionEffect motionEffect = behaviorFactory.CreateMotionEffect();

                    // Define a motion path: move from the current position 300 points to the right
                    MotionPath motionPath = new MotionPath();

                    // Start point (relative coordinates)
                    System.Drawing.PointF[] startPoints = new System.Drawing.PointF[]
                    {
                        new System.Drawing.PointF(0, 0)
                    };
                    motionPath.Add(
                        MotionCommandPathType.MoveTo,
                        startPoints,
                        MotionPathPointsType.Straight,
                        true);

                    // End point (relative coordinates)
                    System.Drawing.PointF[] endPoints = new System.Drawing.PointF[]
                    {
                        new System.Drawing.PointF(300, 0)
                    };
                    motionPath.Add(
                        MotionCommandPathType.LineTo,
                        endPoints,
                        MotionPathPointsType.Straight,
                        true);

                    // Assign the path to the motion effect
                    motionEffect.Path = motionPath;
                    motionEffect.PathEditMode = MotionPathEditMode.Relative;

                    // Attach the motion effect to the effect's behaviors collection
                    effect.Behaviors.Add(motionEffect);

                    // Apply a slide transition (optional)
                    slide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                    slide.SlideShowTransition.Duration = 2000; // duration in milliseconds

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}