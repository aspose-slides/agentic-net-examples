using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.IShape shape = slide.Shapes[0];
            Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
                return;
            }

            // Add initial fade effect to the chart
            slide.Timeline.MainSequence.AddEffect(
                chart,
                Aspose.Slides.Animation.EffectType.Fade,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Get series count
            System.Int32 seriesCount = chart.ChartData.Series.Count;

            // Add appear effect for each series
            Aspose.Slides.Animation.Sequence seq = (Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence;
            for (System.Int32 s = 0; s < seriesCount; s++)
            {
                seq.AddEffect(
                    chart,
                    Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
                    s,
                    Aspose.Slides.Animation.EffectType.Appear,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}