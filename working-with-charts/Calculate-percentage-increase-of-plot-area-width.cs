// -----------------------------------------------------------------------------
// Example: Calculate percentage increase of plot area width using C#
//
// Description:
// Demonstrates how to calculate the percentage increase of a chart's plot area
// width when switching the layout target from Outer (including axes and labels)
// to Inner (excluding axes and labels) using Aspose.Slides for .NET. The example
// creates a presentation, adds a chart with a manual layout, measures the plot
// area widths for both layout targets, computes the increase, outputs the
// values, and saves the presentation.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Chart, PlotArea, LayoutTargetType, 
// PercentageIncrease, OfficeAutomation, PresentationProcessing
//
// Use Cases:
// - Determine how plot area dimensions change with different layout targets.
// - Build utilities that need to compare chart layout measurements.
// - Automate reporting of chart size adjustments in PowerPoint files.
// - Validate visual layout changes during PPTX generation or modification.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartPlotAreaWidthIncrease
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a chart with manual layout
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20f, 100f, 600f, 400f);

            // Define manual layout for the plot area (fraction of chart size)
            chart.PlotArea.AsILayoutable.X = 0.2f;
            chart.PlotArea.AsILayoutable.Y = 0.2f;
            chart.PlotArea.AsILayoutable.Width = 0.7f;
            chart.PlotArea.AsILayoutable.Height = 0.7f;

            // First layout target: Outer (including axis and labels)
            chart.PlotArea.LayoutTargetType = LayoutTargetType.Outer;
            chart.ValidateChartLayout();
            float outerWidth = chart.PlotArea.ActualWidth;

            // Second layout target: Inner (excluding axis and labels)
            chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
            chart.ValidateChartLayout();
            float innerWidth = chart.PlotArea.ActualWidth;

            // Calculate percentage increase from Outer to Inner
            float increase = ((innerWidth - outerWidth) / outerWidth) * 100f;

            // Output the result
            Console.WriteLine("Outer Plot Area Width: " + outerWidth);
            Console.WriteLine("Inner Plot Area Width: " + innerWidth);
            Console.WriteLine("Percentage increase: " + increase + "%");

            // Save the presentation
            presentation.Save("ChartPlotAreaWidthIncrease.pptx", SaveFormat.Pptx);
        }
    }
}
