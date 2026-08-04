// -----------------------------------------------------------------------------
// Example: Create ISequence animation object for chart using C#
//
// Description:
// Demonstrates how to create an ISequence animation object for a chart using C#
// and Aspose.Slides for .NET. The example shows how to add a chart to a slide,
// obtain the slide's main animation sequence, and apply fade and appear effects
// to the chart and its series. This pattern can be used to automate PPTX
// animation workflows in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, ISequence, Animation, Chart,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of ISequence animation objects for charts.
// - Build C# tools for adding animations to PowerPoint presentations.
// - Generate or modify PPTX files with animated charts in .NET applications.
// - Validate animation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0f, 0f, 500f, 400f);

            // Obtain the main animation sequence for the slide
            Aspose.Slides.Animation.ISequence sequence = slide.Timeline.MainSequence;

            // Add a fade effect for the whole chart
            sequence.AddEffect(
                chart,
                EffectType.Fade,
                EffectSubtype.None,
                EffectTriggerType.AfterPrevious);

            // Add appear effects for the first two series (if they exist)
            sequence.AddEffect(
                chart,
                EffectChartMajorGroupingType.BySeries,
                0,
                EffectType.Appear,
                EffectSubtype.None,
                EffectTriggerType.AfterPrevious);
            sequence.AddEffect(
                chart,
                EffectChartMajorGroupingType.BySeries,
                1,
                EffectType.Appear,
                EffectSubtype.None,
                EffectTriggerType.AfterPrevious);

            // Save the presentation
            presentation.Save("AnimatedChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException)
        {
            // Input file not found (if loading an existing presentation)
        }
        // Format not supported exception handling can be added here
        catch (Exception)
        {
            // General exception handling
        }
    }
}
