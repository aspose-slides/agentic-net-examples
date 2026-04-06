using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace AsposeSlidesAnimationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "ZoomRotateAnimation_out.pptx";

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle shape to animate
                IAutoShape shape = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
                shape.TextFrame.Text = "Zoom & Rotate";

                // Add a Zoom effect (Entrance class)
                IEffect zoomEffect = slide.Timeline.MainSequence.AddEffect(
                    shape,
                    EffectType.Zoom,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Create a rotation behavior and attach it to the same effect
                BehaviorFactory behaviorFactory = new BehaviorFactory();
                IRotationEffect rotationBehavior = behaviorFactory.CreateRotationEffect();
                // Rotate 360 degrees
                rotationBehavior.To = 360f;
                // Add the rotation behavior to the effect's behavior collection
                zoomEffect.Behaviors.Add(rotationBehavior);

                // Save the presentation
                try
                {
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    // Handle unsupported format or other save errors
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }

            // Verify that the file was created
            if (File.Exists(outputPath))
            {
                Console.WriteLine("Presentation saved successfully: " + Path.GetFullPath(outputPath));
            }
            else
            {
                Console.WriteLine("Failed to create the presentation file.");
            }
        }
    }
}