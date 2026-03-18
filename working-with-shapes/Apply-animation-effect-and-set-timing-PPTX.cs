using System;
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

            // Add a rectangle shape with text
            Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);
            shape.TextFrame.Text = "Animated Shape";

            // Add a Fly animation effect to the shape
            Aspose.Slides.Animation.IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(
                shape,
                Aspose.Slides.Animation.EffectType.Fly,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Set the effect duration to 2 seconds (float literal)
            effect.Timing.Duration = 2.0F;

            // Save the presentation
            presentation.Save("AnimatedShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}