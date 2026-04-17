using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace AddSeriesAnimation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "AddSeriesAnimation.pptx";

            // Ensure the directory for the output file exists
            string outputDir = Path.GetDirectoryName(Path.GetFullPath(outputPath));
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart to the slide
                IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f, 50f, 500f, 400f);

                // (Optional) Populate chart with sample data if needed
                // ...

                // Get the main animation sequence of the slide
                ISequence mainSequence = slide.Timeline.MainSequence;

                // Add a series animation effect: animate by series, first series (index 0),
                // using Fly entrance effect, no subtype, triggered AfterPrevious
                IEffect effect = mainSequence.AddEffect(
                    chart,
                    EffectChartMajorGroupingType.BySeries,
                    0,
                    EffectType.Fly,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Save the presentation
                try
                {
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., I/O errors)
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
        }
    }
}