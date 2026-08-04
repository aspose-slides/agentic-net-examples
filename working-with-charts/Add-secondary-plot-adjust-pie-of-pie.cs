// -----------------------------------------------------------------------------
// Example: Add secondary plot adjust pie of pie using C#
//
// Description:
// Demonstrates how to add a secondary plot and adjust the size of the secondary
// pie in a Pie of Pie chart using C# and Aspose.Slides for .NET. The example
// creates a new presentation, inserts a Pie of Pie chart, configures data
// label visibility, sets secondary pie size, split type, and split position,
// then saves the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Pie of Pie, Secondary Plot, Adjust,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a secondary plot and adjusting its size in a Pie of Pie chart.
// - Build C# tools for PowerPoint presentation processing involving complex charts.
// - Generate or transform PPTX files with customized chart configurations in .NET applications.
// - Validate chart layout workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a Pie of Pie chart to the first slide
                IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);

                // Show values on data labels for the first series
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

                // Adjust the size of the secondary pie (percentage of the first pie)
                chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 50; // 50%

                // Set the split type to split by percentage
                chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = PieSplitType.ByPercentage;

                // Define the split position (percentage threshold)
                chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 30.0; // 30%

                // Save the presentation
                string outputPath = "SecondaryPieOfPie.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., format not supported)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
