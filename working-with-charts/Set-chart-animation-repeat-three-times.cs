// -----------------------------------------------------------------------------
// Example: Set chart animation repeat three times using C#
//
// Description:
// Demonstrates how to set chart animation repeat three times using C# and 
// Aspose.Slides for .NET. The example creates a new presentation, adds a 
// clustered column chart, applies a fade animation effect to the chart, sets 
// the effect to repeat three times, and saves the presentation as a PPTX file. 
// This pattern can be used to automate PowerPoint animation settings in .NET 
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Animation, Repeat, 
// Three, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting chart animation to repeat three times.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with specific animation settings in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

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
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        IChart chart = slide.Shapes.AddChart(
            ChartType.ClusteredColumn,
            50, 50, 400, 300);

        // Add a fade effect to the chart
        IEffect effect = slide.Timeline.MainSequence.AddEffect(
            chart,
            EffectType.Fade,
            EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

        // Set the effect to repeat three times
        effect.Timing.RepeatCount = 3;

        // Save the presentation
        string outputPath = "ChartAnimationRepeat.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);
        presentation.Dispose();
    }
}
