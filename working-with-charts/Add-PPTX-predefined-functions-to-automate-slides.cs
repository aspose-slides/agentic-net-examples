using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.SlideShow;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 150);
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightBlue;

            // Add a fade animation effect to the shape
            Aspose.Slides.Animation.ISequence mainSequence = slide.Timeline.MainSequence;
            Aspose.Slides.Animation.IEffect effect = mainSequence.AddEffect(
                shape,
                Aspose.Slides.Animation.EffectType.Fade,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Set slide transition
            slide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
            slide.SlideShowTransition.AdvanceOnClick = true;
            slide.SlideShowTransition.AdvanceAfterTime = 3000; // 3 seconds

            // Save the presentation
            presentation.Save("AutomatedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}