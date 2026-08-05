// -----------------------------------------------------------------------------
// Example: Sync chart animation with slide transition using C#
//
// Description:
// Demonstrates how to create a clustered column chart, populate it with data,
// animate the chart series sequentially, and synchronize a slide transition
// (fade, 5 seconds) with the chart animation using Aspose.Slides for .NET.
// The example produces a PPTX file that can be opened in PowerPoint.
//
// Keywords:
// C#, Aspose.Slides, PPTX, chart animation, slide transition, clustered column,
// BySeries animation, Fade transition, presentation automation, Office automation
//
// Use Cases:
// - Generate PowerPoint slides with animated charts for presentations.
// - Automate synchronization of chart animations with slide transitions.
// - Build .NET tools that create or modify PPTX files with advanced animation.
// - Validate chart animation workflows before publishing.
// -----------------------------------------------------------------------------

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
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 400, 300);

        // Populate chart data
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        int defaultWorksheetIndex = 0;
        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));
        Aspose.Slides.Charts.IChartSeries series0 = chart.ChartData.Series[0];
        series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
        series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
        series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[1];
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));

        // Animate the chart by series
        Aspose.Slides.Animation.Sequence seq = (Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence;
        seq.AddEffect(chart,
            Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
            0,
            Aspose.Slides.Animation.EffectType.Appear,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
        seq.AddEffect(chart,
            Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
            1,
            Aspose.Slides.Animation.EffectType.Appear,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Apply a slide transition synchronized with the animation (5 seconds)
        slide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
        slide.SlideShowTransition.AdvanceOnClick = true;
        slide.SlideShowTransition.AdvanceAfterTime = 5000; // milliseconds

        // Save the presentation
        string outputPath = "ChartAnimationWithTransition.pptx";
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}
