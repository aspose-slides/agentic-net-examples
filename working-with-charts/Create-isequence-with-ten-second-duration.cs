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