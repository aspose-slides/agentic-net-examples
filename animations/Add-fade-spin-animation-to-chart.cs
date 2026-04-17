using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace AddFadeSpinAnimationToChart
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "template.pptx";
            Presentation presentation = null;
            try
            {
                if (File.Exists(inputPath))
                {
                    presentation = new Presentation(inputPath);
                }
                else
                {
                    presentation = new Presentation();
                }

                ISlide slide = presentation.Slides[0];

                // Add a chart to the slide
                IChart chart = slide.Shapes.AddChart(
                    ChartType.ClusteredColumn, 50, 50, 400, 300);

                // Add Fade effect to the chart
                slide.Timeline.MainSequence.AddEffect(
                    chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

                // Add Spin effect to the chart
                slide.Timeline.MainSequence.AddEffect(
                    chart, EffectChartMajorGroupingType.BySeries, 0,
                    EffectType.Spin, EffectSubtype.None, EffectTriggerType.AfterPrevious);

                // Save the presentation
                presentation.Save("FadeSpinChart.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle errors such as unsupported format
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}