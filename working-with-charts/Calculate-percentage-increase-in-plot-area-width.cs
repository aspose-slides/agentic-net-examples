// -----------------------------------------------------------------------------
// Example: Calculate percentage increase in plot area width using C#
//
// Description:
// Demonstrates how to calculate the percentage increase in a chart's plot area
// width when switching the LayoutTargetType between Outer and Inner using
// Aspose.Slides for .NET. The example creates a presentation, adds a clustered
// column chart, configures manual layout, retrieves actual widths, computes the
// increase, and saves the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Calculate, Percentage, Increase,
// Plot Area, Chart Layout, LayoutTargetType, Presentation Processing, Office Automation
//
// Use Cases:
// - Determine how plot area dimensions change with different layout targets.
// - Automate analysis of chart layout effects in PowerPoint files.
// - Build tools that validate or adjust chart sizing in .NET applications.
// - Integrate chart layout calculations into reporting or presentation pipelines.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart and cast to Chart to access layout methods
        Aspose.Slides.Charts.Chart chart = (Aspose.Slides.Charts.Chart)slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 20f, 100f, 600f, 400f);

        // Define manual layout for the plot area (as fractions of the chart size)
        chart.PlotArea.AsILayoutable.X = 0.2f;
        chart.PlotArea.AsILayoutable.Y = 0.2f;
        chart.PlotArea.AsILayoutable.Width = 0.7f;
        chart.PlotArea.AsILayoutable.Height = 0.7f;

        // Set LayoutTargetType to Outer and get actual width
        chart.PlotArea.LayoutTargetType = Aspose.Slides.Charts.LayoutTargetType.Outer;
        chart.ValidateChartLayout();
        float outerWidth = chart.PlotArea.ActualWidth;

        // Set LayoutTargetType to Inner and get actual width
        chart.PlotArea.LayoutTargetType = Aspose.Slides.Charts.LayoutTargetType.Inner;
        chart.ValidateChartLayout();
        float innerWidth = chart.PlotArea.ActualWidth;

        // Calculate percentage increase in plot area width
        float percentageIncrease = ((innerWidth - outerWidth) / outerWidth) * 100f;

        // Output the results
        Console.WriteLine("Outer Actual Width: " + outerWidth);
        Console.WriteLine("Inner Actual Width: " + innerWidth);
        Console.WriteLine("Percentage increase: " + percentageIncrease + "%");

        // Save the presentation
        presentation.Save("ChartLayoutTargetTypeDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}
