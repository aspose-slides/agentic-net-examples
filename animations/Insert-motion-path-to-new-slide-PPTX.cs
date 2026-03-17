using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input and output files
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

            try
            {
                // Load the existing presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Add a new empty slide based on the first layout slide
                    Aspose.Slides.ISlide newSlide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

                    // Add a rectangle shape to the new slide
                    Aspose.Slides.IAutoShape rectShape = newSlide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 100);
                    rectShape.AddTextFrame("Motion Path Demo");

                    // Add a motion path effect to the rectangle shape
                    Aspose.Slides.Animation.IEffect effect = newSlide.Timeline.MainSequence.AddEffect(
                        rectShape,
                        Aspose.Slides.Animation.EffectType.PathUser,
                        Aspose.Slides.Animation.EffectSubtype.None,
                        Aspose.Slides.Animation.EffectTriggerType.OnClick);

                    // Retrieve the motion effect behavior from the effect
                    Aspose.Slides.Animation.IMotionEffect motionEffect = (Aspose.Slides.Animation.IMotionEffect)effect.Behaviors[0];

                    // Define points for the motion path
                    PointF[] pts = new PointF[1];

                    // First segment: move to (200, 0) relative to the shape
                    pts[0] = new PointF(200, 0);
                    motionEffect.Path.Add(
                        Aspose.Slides.Animation.MotionCommandPathType.LineTo,
                        pts,
                        Aspose.Slides.Animation.MotionPathPointsType.Auto,
                        false);

                    // Second segment: move to (0, 150) relative to the current position
                    pts[0] = new PointF(0, 150);
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

                    // Save the modified presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}