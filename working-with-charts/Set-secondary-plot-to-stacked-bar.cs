// -----------------------------------------------------------------------------
// Example: Set secondary plot to stacked bar using C#
//
// Description:
// Demonstrates how to configure the secondary plot of a PieOfPie chart as a
// stacked bar using C# and Aspose.Slides for .NET. The example creates a new
// presentation, adds a PieOfPie chart, sets secondary plot size, split type,
// and split position, then saves the result. This pattern can be used to
// automate PowerPoint chart customizations in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Secondary Plot, Stacked Bar,
// Chart Customization, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting secondary plot to stacked bar in charts.
// - Build C# utilities for PowerPoint chart manipulation.
// - Generate or transform PPTX files with customized chart layouts.
// - Validate chart configurations before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "SecondaryPlotStackedBar.pptx";

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a PieOfPie chart (supports secondary plot options)
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.PieOfPie, 50f, 50f, 500f, 400f);

            // Show values for the first series
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

            // Configure secondary plot (second pie/bar) as a stacked bar representation
            // Set the size of the secondary plot (percentage of the primary plot)
            chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 30; // 30%

            // Define how data points are split between primary and secondary plots
            chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;

            // Position (percentage) at which points are split
            chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 10.0;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // General exception handling (e.g., I/O errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
