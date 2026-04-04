using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace CreatePresentationWithAnimations
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // -------------------- Slide 1 --------------------
                    ISlide slide1 = presentation.Slides[0];
                    IAutoShape shape1 = (IAutoShape)slide1.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 100, 400, 100);
                    shape1.TextFrame.Text = "Slide 1 - Fade Entrance";
                    // Add Fade entrance animation
                    slide1.Timeline.MainSequence.AddEffect(
                        shape1,
                        Aspose.Slides.Animation.EffectType.Fade,
                        Aspose.Slides.Animation.EffectSubtype.None,
                        Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                    // -------------------- Slide 2 --------------------
                    ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                    IAutoShape shape2 = (IAutoShape)slide2.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 100, 400, 100);
                    shape2.TextFrame.Text = "Slide 2 - Fly Entrance";
                    // Add Fly entrance animation
                    slide2.Timeline.MainSequence.AddEffect(
                        shape2,
                        Aspose.Slides.Animation.EffectType.Fly,
                        Aspose.Slides.Animation.EffectSubtype.None,
                        Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                    // -------------------- Slide 3 --------------------
                    ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                    IAutoShape shape3 = (IAutoShape)slide3.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 100, 400, 100);
                    shape3.TextFrame.Text = "Slide 3 - Zoom Entrance";
                    // Add Zoom entrance animation
                    slide3.Timeline.MainSequence.AddEffect(
                        shape3,
                        Aspose.Slides.Animation.EffectType.Zoom,
                        Aspose.Slides.Animation.EffectSubtype.None,
                        Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                    // Save the presentation
                    presentation.Save("ThreeSlideAnimations.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxException ex)
            {
                // Handle Aspose.Slides specific exceptions (e.g., unsupported format)
                Console.WriteLine("Aspose.Slides error: " + ex.Message);
                // Format not supported
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}