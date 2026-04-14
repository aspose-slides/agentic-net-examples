using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a clustered column chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 450f, 300f);

        // Configure 3‑D rotation for the chart
        chart.Rotation3D.RightAngleAxes = false; // enable perspective
        chart.Rotation3D.RotationY = 30; // rotate 30 degrees around the Y‑axis

        // Add a fade‑in effect for the chart when the slide is shown
        ISlide slide = presentation.Slides[0];
        slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

        // Animate each series to appear one after another
        int seriesCount = chart.ChartData.Series.Count;
        for (int s = 0; s < seriesCount; s++)
        {
            ((Sequence)slide.Timeline.MainSequence).AddEffect(
                chart,
                EffectChartMajorGroupingType.BySeries,
                s,
                EffectType.Appear,
                EffectSubtype.None,
                EffectTriggerType.AfterPrevious);
        }

        // Save the presentation
        string outputPath = "3DRotationAnimation.pptx";
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}