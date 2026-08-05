// -----------------------------------------------------------------------------
// Example: Export animated chart as TIFF for print using C#
//
// Description:
// Demonstrates how to create a clustered column chart, apply a series of
// animations (fade, by series, and by element in series), and export the
// animated slide to a high‑resolution TIFF image suitable for printing using
// Aspose.Slides for .NET. The example includes setting TIFF options such as DPI
// and compression.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Animated, Chart, TIFF,
// Presentation Processing, Office Automation, High Resolution Print
//
// Use Cases:
// - Automate creation and animation of charts in PowerPoint presentations.
// - Generate print‑ready TIFF files from animated slides.
// - Integrate chart animation and export functionality into .NET applications.
// - Validate animated chart rendering before publishing.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        // Output TIFF file path
        string outputTiffPath = "AnimatedChart.tiff";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 450f, 300f);

        // Animate the chart (fade in, then by series, then by element in series)
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        slide.Timeline.MainSequence.AddEffect(
            chart,
            Aspose.Slides.Animation.EffectType.Fade,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        int seriesCount = chart.ChartData.Series.Count;
        for (int s = 0; s < seriesCount; s++)
        {
            ((Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence).AddEffect(
                chart,
                Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
                s,
                Aspose.Slides.Animation.EffectType.Appear,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
        }

        for (int s = 0; s < seriesCount; s++)
        {
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[s];
            int pointCount = series.DataPoints.Count;
            for (int p = 0; p < pointCount; p++)
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

        // Export the presentation (including the animated chart) to a high‑quality TIFF image
        Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
        tiffOptions.DpiX = 300; // High resolution for print
        tiffOptions.DpiY = 300;
        tiffOptions.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.LZW;

        try
        {
            presentation.Save(outputTiffPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Save presentation before exit (already saved as TIFF)
        presentation.Dispose();
    }
}
