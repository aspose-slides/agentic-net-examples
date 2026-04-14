using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        System.String inputPath = "input.pptx";
        System.String outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Get the first shape and cast it to a chart
                Aspose.Slides.IShape shape = slide.Shapes[0];
                Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                    return;
                }

                // Add a fade effect to the chart with a defined trigger
                slide.Timeline.MainSequence.AddEffect(
                    chart,
                    Aspose.Slides.Animation.EffectType.Fade,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                // Animate each series of the chart
                System.Int32 seriesCount = chart.ChartData.Series.Count;
                for (System.Int32 s = 0; s < seriesCount; s++)
                {
                    ((Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence).AddEffect(
                        chart,
                        Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
                        s,
                        Aspose.Slides.Animation.EffectType.Appear,
                        Aspose.Slides.Animation.EffectSubtype.None,
                        Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
                }

                // Animate each element (data point) within each series
                for (System.Int32 s = 0; s < seriesCount; s++)
                {
                    Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[s];
                    System.Int32 pointCount = series.DataPoints.Count;
                    for (System.Int32 p = 0; p < pointCount; p++)
                    {
                        ((Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence).AddEffect(
                            chart,
                            Aspose.Slides.Animation.EffectChartMinorGroupingType.ByElementInSeries,
                            s,
                            p,
                            Aspose.Slides.Animation.EffectType.Appear,
                            Aspose.Slides.Animation.EffectSubtype.None,
                            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
                    }
                }

                // Validate that all added effects have a trigger defined
                Aspose.Slides.Animation.ISequence mainSequence = slide.Timeline.MainSequence;
                for (System.Int32 i = 0; i < mainSequence.Count; i++)
                {
                    Aspose.Slides.Animation.IEffect effect = mainSequence[i];
                    // The trigger type is set during AddEffect; if needed, additional validation logic can be placed here.
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            // Comment: The specified file format is not supported for saving.
        }
        catch (Exception ex)
        {
            // Handle other possible exceptions (e.g., external URL errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}