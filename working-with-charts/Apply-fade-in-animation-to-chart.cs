using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace ApplyFadeInAnimationToChart
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

                // Add a clustered column chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 400f, 300f);

                // Apply a fade-in animation to the chart when the slide appears
                // The animation will start after the previous animation (or immediately if none)
                slide.Timeline.MainSequence.AddEffect(
                    chart,
                    EffectChartMajorGroupingType.BySeries,
                    0,
                    EffectType.Fade,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Save the presentation
                try
                {
                    presentation.Save("ChartFadeIn.pptx", SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    // Handle unsupported format exception
                    // Format not supported
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
        }
    }
}