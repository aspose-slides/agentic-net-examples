using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation presentation = new Presentation())
            {
                ISlide slide = presentation.Slides[0];

                // Apply wipe transition
                slide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Wipe;
                slide.SlideShowTransition.Duration = 2000; // 2 seconds

                // Add a rectangle shape with initial color
                IAutoShape shape = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 200);
                shape.FillFormat.FillType = FillType.Solid;
                shape.FillFormat.SolidFillColor.Color = Color.Blue;

                // Add a color fade effect that changes the fill color after the transition
                IEffect effect = slide.Timeline.MainSequence.AddEffect(
                    shape,
                    Aspose.Slides.Animation.EffectType.ChangeFillColor,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
                effect.AfterAnimationColor.Color = Color.Red;

                // Save the presentation
                presentation.Save("WipeColorFade.pptx", SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., file I/O)
        }
    }
}