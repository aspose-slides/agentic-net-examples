// -----------------------------------------------------------------------------
// Example: Add secondary plot to Bar of Pie chart and reorder series using C#
//
// Description:
// Demonstrates how to create a Bar of Pie chart, configure its secondary plot
// (size, split type and split position) and change the order of data series
// using Aspose.Slides for .NET. The example builds a presentation, adds the
// chart, applies secondary plot settings, reorders the first two series, and
// saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bar of Pie, Secondary Plot,
// Series Order, Chart Manipulation, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a secondary plot to a Bar of Pie chart.
// - Adjust Bar of Pie chart split parameters programmatically.
// - Reorder chart series to control visual layout.
// - Build .NET tools for PowerPoint chart customization and automation.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a Bar of Pie chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.BarOfPie, 50f, 50f, 500f, 400f);

        // Configure secondary plot options
        chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 150; // size of secondary bar (percentage)
        chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
        chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 30.0; // split at 30%

        // Adjust the order of data series (example: reverse order of first two series)
        if (chart.ChartData.Series.Count > 0)
        {
            chart.ChartData.Series[0].Order = 2;
        }
        if (chart.ChartData.Series.Count > 1)
        {
            chart.ChartData.Series[1].Order = 1;
        }

        // Save the presentation
        try
        {
            presentation.Save("BarOfPieSecondaryPlot.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}
