using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 450f, 300f);

        // Set 3‑D rotation (rotate 45 degrees around Y‑axis)
        chart.Rotation3D.RotationY = 45;

        // Add an animation effect that plays after the previous (on slide show start)
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        slide.Timeline.MainSequence.AddEffect(
            chart,
            Aspose.Slides.Animation.EffectType.Appear,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Save the presentation
        presentation.Save("3DRotationAnimation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}