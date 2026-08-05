// -----------------------------------------------------------------------------
// Example: Set series animation trigger to onclick using C#
//
// Description:
// Demonstrates how to add a clustered column chart to a presentation and
// configure an animation effect that triggers each series on click using
// Aspose.Slides for .NET. The example creates a new PPTX file, inserts a chart,
// applies a fade animation grouped by series with an OnClick trigger, and
// saves the result. This pattern helps automate chart animation settings in
// PowerPoint files within .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Series, Animation, Trigger,
// Onclick, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting series animation triggers to onclick for charts.
// - Build C# utilities for PowerPoint presentation processing and animation.
// - Generate or modify PPTX files with chart animations in .NET applications.
// - Validate and test presentation workflows involving chart animations.
// -----------------------------------------------------------------------------
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
