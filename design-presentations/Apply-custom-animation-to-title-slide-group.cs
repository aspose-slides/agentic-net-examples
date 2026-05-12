using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AnimationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                if (File.Exists(inputPath))
                {
                    using (Presentation presentation = new Presentation(inputPath))
                    {
                        ISlide slide = presentation.Slides[0];

                        // Add shapes to the title slide
                        IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
                        IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 300, 50, 200, 100);

                        // Apply custom animation sequence
                        slide.Timeline.MainSequence.AddEffect(
                            shape1,
                            Aspose.Slides.Animation.EffectType.Fade,
                            Aspose.Slides.Animation.EffectSubtype.None,
                            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                        slide.Timeline.MainSequence.AddEffect(
                            shape2,
                            Aspose.Slides.Animation.EffectType.Fade,
                            Aspose.Slides.Animation.EffectSubtype.None,
                            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                        // Save presentation
                        presentation.Save(outputPath, SaveFormat.Pptx);
                    }
                }
                else
                {
                    using (Presentation presentation = new Presentation())
                    {
                        ISlide slide = presentation.Slides[0];

                        // Add shapes to the title slide
                        IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
                        IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 300, 50, 200, 100);

                        // Apply custom animation sequence
                        slide.Timeline.MainSequence.AddEffect(
                            shape1,
                            Aspose.Slides.Animation.EffectType.Fade,
                            Aspose.Slides.Animation.EffectSubtype.None,
                            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                        slide.Timeline.MainSequence.AddEffect(
                            shape2,
                            Aspose.Slides.Animation.EffectType.Fade,
                            Aspose.Slides.Animation.EffectSubtype.None,
                            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                        // Save presentation
                        presentation.Save(outputPath, SaveFormat.Pptx);
                    }
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, Aspose.Slides errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}