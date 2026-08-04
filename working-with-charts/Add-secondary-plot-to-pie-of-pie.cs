// -----------------------------------------------------------------------------
// Example: Add secondary plot to pie of pie using C#
//
// Description:
// Demonstrates how to add a secondary plot to a Pie of Pie chart using C# and 
// Aspose.Slides for .NET. The example creates a new presentation, inserts a 
// Pie of Pie chart, configures the secondary pie size and split criteria, and 
// saves the result as a PPTX file. This pattern can be used to automate chart 
// customization in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Pie of Pie, Secondary Plot, 
// Chart Customization, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding secondary plot to Pie of Pie charts.
// - Build C# tools for customizing chart appearance in PowerPoint.
// - Generate or modify PPTX files with advanced chart configurations.
// - Validate chart settings before publishing presentations.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddSecondaryPlotToPieOfPie
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Add a Pie of Pie chart with float literals for position and size
                    IChart chart = slide.Shapes.AddChart(ChartType.PieOfPie, 0f, 0f, 500f, 400f);

                    // Access the first series (the primary series)
                    IChartSeries series = chart.ChartData.Series[0];

                    // Adjust the size of the secondary pie (percentage of the first pie)
                    // Use the ParentSeriesGroup to set the writable property
                    IChartSeriesGroup group = series.ParentSeriesGroup;
                    group.SecondPieSize = (ushort)150; // 150% of the first pie size

                    // Optionally, set the split position to define which points go to the secondary pie
                    group.PieSplitBy = PieSplitType.ByValue;
                    group.PieSplitPosition = 30.0; // values less than 30 go to the secondary pie

                    // Save the presentation
                    pres.Save("PieOfPie_SecondaryPlot.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, external resources)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
