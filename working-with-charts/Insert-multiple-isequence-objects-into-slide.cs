using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            using (var presentation = new Presentation())
            {
                var slide = presentation.Slides[0];

                // Add first chart
                var chart1 = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 400, 300);
                // Add second chart
                var chart2 = slide.Shapes.AddChart(ChartType.Pie, 500, 50, 300, 300);

                var mainSequence = slide.Timeline.MainSequence;

                // Animate first chart by series
                mainSequence.AddEffect(chart1, EffectChartMajorGroupingType.BySeries, 0,
                    EffectType.Fly, EffectSubtype.None, EffectTriggerType.AfterPrevious);

                // Animate second chart by category
                mainSequence.AddEffect(chart2, EffectChartMajorGroupingType.ByCategory, 0,
                    EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

                // Save the presentation
                presentation.Save("MultipleChartAnimations_out.pptx", SaveFormat.Pptx);
            }
        }
        catch (FileNotFoundException ex)
        {
            // Handle missing file if any external file is used
            Console.WriteLine("File not found: " + ex.Message);
        }
        catch (NotSupportedException ex)
        {
            // format not supported
            Console.WriteLine("Unsupported format: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}