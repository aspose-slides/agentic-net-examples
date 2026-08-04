// -----------------------------------------------------------------------------
// Example: Add secondary plot adjust bar of pie using C#
//
// Description:
// Demonstrates how to add a secondary plot (Pie of Pie chart) and adjust the
// bar (size) of the secondary pie using C# and Aspose.Slides for .NET. The
// example creates a presentation, inserts a Pie of Pie chart, configures data
// labels, sets the secondary pie size, defines the split method and threshold,
// and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Secondary Plot, Pie of Pie,
// Bar of Pie, Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a secondary plot and adjusting its size in a Pie of Pie chart.
// - Build C# tools for PowerPoint chart manipulation.
// - Generate or transform PPTX files with customized chart settings in .NET applications.
// - Validate chart configurations before publishing or integration.
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

                // Add a Pie of Pie chart (secondary plot) to the first slide
                ISlide slide = presentation.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 400, 400);

                // Enable showing values on the primary pie
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

                // Adjust secondary plot size (percentage of primary pie)
                chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 50; // 50%

                // Set split method to ByPercentage and define the split threshold
                chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = PieSplitType.ByPercentage;
                chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 5.0; // Split at 5%

                // Save the presentation
                string outputPath = "BarOfPieChart.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
