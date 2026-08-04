// -----------------------------------------------------------------------------
// Example: Create isequence with ten second duration using C#
//
// Description:
// Demonstrates how to create an animation sequence with a total duration of ten
// seconds for a chart on the first slide using C# and Aspose.Slides for .NET.
// The example loads an existing presentation, adds a base fade effect to the
// chart, then adds appear effects for each series, spacing them evenly over a
// ten‑second interval. The modified presentation is saved as a new PPTX file.
// This pattern can be used to automate timed chart animations in PowerPoint.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, ISequence, Chart, Animation,
// Duration, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of chart animation sequences with a fixed total duration.
// - Build C# tools for timed PowerPoint chart presentations.
// - Generate or modify PPTX files with custom animation timing in .NET applications.
// - Validate and preview chart animations before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception)
        {
            // format not supported
            Console.WriteLine("File format not supported.");
            return;
        }

        Aspose.Slides.ISlide slide = presentation.Slides[0];
        Aspose.Slides.Animation.ISequence mainSeq = slide.Timeline.MainSequence;

        Aspose.Slides.IShape shape = slide.Shapes[0];
        Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
        if (chart == null)
        {
            Console.WriteLine("No chart found on the first slide.");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
            return;
        }

        // Add a base fade effect for the chart
        mainSeq.AddEffect(chart, Aspose.Slides.Animation.EffectType.Fade, Aspose.Slides.Animation.EffectSubtype.None, Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Cast to Sequence to add series effects
        Aspose.Slides.Animation.Sequence customSeq = (Aspose.Slides.Animation.Sequence)mainSeq;

        int seriesCount = chart.ChartData.Series.Count;
        int totalDurationMs = 10000; // 10 seconds
        int delayPerSeries = totalDurationMs / seriesCount;

        // Set default delay for generated animations
        using (Aspose.Slides.Export.PresentationAnimationsGenerator generator = new Aspose.Slides.Export.PresentationAnimationsGenerator(presentation))
        {
            generator.DefaultDelay = delayPerSeries;

            for (int s = 0; s < seriesCount; s++)
            {
                customSeq.AddEffect(
                    chart,
                    Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
                    s,
                    Aspose.Slides.Animation.EffectType.Appear,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
            }
        }

        // Save presentation before exit
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}
