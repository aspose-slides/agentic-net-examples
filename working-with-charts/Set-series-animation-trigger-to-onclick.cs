using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace SetSeriesAnimationOnClick
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50, 50, 500, 400);

                // Add an animation effect for the first series (index 0)
                // The effect animates the series by series, triggers on click
                IEffect effect = slide.Timeline.MainSequence.AddEffect(
                    chart,
                    EffectChartMajorGroupingType.BySeries,
                    0,
                    EffectType.Fade,
                    EffectSubtype.None,
                    EffectTriggerType.OnClick);

                // Save the presentation
                presentation.Save("SetSeriesAnimationOnClick.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}