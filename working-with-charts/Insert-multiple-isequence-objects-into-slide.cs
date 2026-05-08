using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;

namespace InsertMultipleSequences
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (var presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                var slide = presentation.Slides[0];

                // Add first chart (Clustered Column)
                var chart1 = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f, 50f, 400f, 300f);

                // Add second chart (Pie)
                var chart2 = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Pie,
                    500f, 50f, 400f, 300f);

                // Get the main animation sequence of the slide
                var mainSequence = slide.Timeline.MainSequence;

                // Add animation effect for the first chart (by series)
                mainSequence.AddEffect(
                    chart1,
                    Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
                    0,
                    Aspose.Slides.Animation.EffectType.Fly,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                // Add animation effect for the second chart (by category)
                mainSequence.AddEffect(
                    chart2,
                    Aspose.Slides.Animation.EffectChartMajorGroupingType.ByCategory,
                    0,
                    Aspose.Slides.Animation.EffectType.Fly,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                // Save the presentation
                try
                {
                    presentation.Save("MultipleSequences.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception)
                {
                    // Handle other exceptions (e.g., I/O errors)
                }
            }
        }
    }
}