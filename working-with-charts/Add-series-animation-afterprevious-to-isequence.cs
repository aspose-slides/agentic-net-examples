using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        try
        {
            if (File.Exists(inputPath))
            {
                // Load existing presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Get the first slide
                    Aspose.Slides.ISlide slide = presentation.Slides[0];
                    // Get the shape collection
                    Aspose.Slides.IShapeCollection shapes = slide.Shapes;
                    // Assume the first shape is a chart
                    Aspose.Slides.Charts.IChart chart = shapes[0] as Aspose.Slides.Charts.IChart;
                    if (chart != null)
                    {
                        // Add a fade effect to the chart (optional)
                        slide.Timeline.MainSequence.AddEffect(
                            chart,
                            Aspose.Slides.Animation.EffectType.Fade,
                            Aspose.Slides.Animation.EffectSubtype.None,
                            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                        // Cast the main sequence to Sequence to access AddEffect overloads
                        Aspose.Slides.Animation.Sequence sequence = (Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence;

                        // Add series animation (BySeries) with AfterPrevious trigger
                        sequence.AddEffect(
                            chart,
                            Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
                            0, // series index
                            Aspose.Slides.Animation.EffectType.Appear,
                            Aspose.Slides.Animation.EffectSubtype.None,
                            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            else
            {
                // Input file not found – create a new presentation with a sample chart
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[0];
                    // Add a clustered column chart
                    Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                        Aspose.Slides.Charts.ChartType.ClusteredColumn,
                        0,
                        0,
                        500,
                        400);

                    // Add a fade effect to the chart
                    slide.Timeline.MainSequence.AddEffect(
                        chart,
                        Aspose.Slides.Animation.EffectType.Fade,
                        Aspose.Slides.Animation.EffectSubtype.None,
                        Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                    // Cast the main sequence to Sequence
                    Aspose.Slides.Animation.Sequence sequence = (Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence;

                    // Add series animation (BySeries) with AfterPrevious trigger
                    sequence.AddEffect(
                        chart,
                        Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
                        0,
                        Aspose.Slides.Animation.EffectType.Appear,
                        Aspose.Slides.Animation.EffectSubtype.None,
                        Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                    // Save the new presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex) when (ex is System.Net.WebException || ex is System.Net.Http.HttpRequestException)
        {
            // Handle external URL or web service exceptions
            Console.WriteLine("Network error: " + ex.Message);
        }
    }
}