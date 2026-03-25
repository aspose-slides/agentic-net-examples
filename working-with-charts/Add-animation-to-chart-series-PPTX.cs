using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace AddChartSeriesAnimation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine source presentation path (optional)
            string inputPath = args.Length > 0 ? args[0] : string.Empty;
            // Output file path
            string outputPath = "ChartSeriesAnimation_out.pptx";

            // Create or load presentation
            Aspose.Slides.Presentation presentation;
            if (!string.IsNullOrEmpty(inputPath))
            {
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine("Input file not found: " + inputPath);
                    return;
                }
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }

            // Access first slide
            ISlide slide = presentation.Slides[0];

            // Add a sample chart
            IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0f, 0f, 500f, 400f);

            // Add animation effect to the first series of the chart
            // EffectChartMajorGroupingType.BySeries animates by series
            // Index 0 refers to the first series
            // EffectType.Fly with subtype Left, triggered on click
            IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(
                chart,
                Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
                0,
                Aspose.Slides.Animation.EffectType.Fly,
                Aspose.Slides.Animation.EffectSubtype.Left,
                Aspose.Slides.Animation.EffectTriggerType.OnClick);

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}