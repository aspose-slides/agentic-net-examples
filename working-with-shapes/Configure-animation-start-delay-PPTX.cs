using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

public class Program
{
    public static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide (automatically added)
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to the slide
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

            // Add a Fade effect to the shape
            Aspose.Slides.Animation.IEffect effect = slide.Timeline.MainSequence.AddEffect(
                shape,
                Aspose.Slides.Animation.EffectType.Fade,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Set start‑delay (trigger delay) to 2 seconds
            effect.Timing.TriggerDelayTime = 2.0f;

            // Save the presentation
            presentation.Save("AnimatedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}