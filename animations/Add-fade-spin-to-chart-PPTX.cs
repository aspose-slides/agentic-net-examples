using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace CustomChartAnimation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string dataDir = @"C:\SlidesData\";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found. Creating a new presentation.");
            }

            // Load or create presentation
            Aspose.Slides.Presentation presentation;
            try
            {
                if (File.Exists(inputPath))
                {
                    presentation = new Aspose.Slides.Presentation(inputPath);
                }
                else
                {
                    presentation = new Aspose.Slides.Presentation();
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Ensure there is at least one slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Ensure there is at least one chart on the slide; if not, add a simple chart
            Aspose.Slides.IShape shape = slide.Shapes.Count > 0 ? slide.Shapes[0] : null;
            Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
            if (chart == null)
            {
                chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 400, 300);
            }

            // Add a Fade effect to the chart
            slide.Timeline.MainSequence.AddEffect(
                chart,
                EffectType.Fade,
                EffectSubtype.None,
                EffectTriggerType.AfterPrevious);

            // Add a Spin effect to the chart (by series, first series)
            slide.Timeline.MainSequence.AddEffect(
                chart,
                EffectChartMajorGroupingType.BySeries,
                0,
                EffectType.Spin,
                EffectSubtype.None,
                EffectTriggerType.AfterPrevious);

            // Save the presentation
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully.");
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
        }
    }
}