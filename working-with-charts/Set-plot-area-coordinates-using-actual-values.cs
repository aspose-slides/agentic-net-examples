// -----------------------------------------------------------------------------
// Example: Set plot area coordinates using actual values using C#
//
// Description:
// Demonstrates how to retrieve the actual plot area dimensions of a chart
// and set the plot area position using those values with Aspose.Slides for .NET.
// The example creates or loads a presentation, adds a clustered column chart,
// obtains the actual X, Y, width, and height of the plot area, and assigns the
// X and Y coordinates back to the plot area. The resulting presentation is saved
// as a PPTX file.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Chart, PlotArea, ActualX, ActualY, 
// Presentation Automation, .NET
//
// Use Cases:
// - Programmatically adjust chart plot area positioning based on actual layout.
// - Build .NET utilities for PowerPoint chart manipulation.
// - Automate PPTX generation or modification with precise chart layout control.
// - Validate and fine‑tune chart appearance in automated workflows.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // If input file does not exist, create a new presentation
        if (!File.Exists(inputPath))
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Add a clustered column chart
                Aspose.Slides.Charts.Chart chart = (Aspose.Slides.Charts.Chart)presentation.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);
                chart.ValidateChartLayout();

                // Retrieve actual plot area dimensions
                float actualX = chart.PlotArea.ActualX;
                float actualY = chart.PlotArea.ActualY;
                float actualWidth = chart.PlotArea.ActualWidth;
                float actualHeight = chart.PlotArea.ActualHeight;

                // Adjust plot area coordinates manually using the retrieved actual values
                chart.PlotArea.AsILayoutable.X = actualX;
                chart.PlotArea.AsILayoutable.Y = actualY;

                // Save the presentation (handle unsupported format)
                try
                {
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (Exception)
                {
                    // Format not supported
                }
            }
        }
        else
        {
            // Load existing presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Add a clustered column chart
                Aspose.Slides.Charts.Chart chart = (Aspose.Slides.Charts.Chart)presentation.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);
                chart.ValidateChartLayout();

                // Retrieve actual plot area dimensions
                float actualX = chart.PlotArea.ActualX;
                float actualY = chart.PlotArea.ActualY;
                float actualWidth = chart.PlotArea.ActualWidth;
                float actualHeight = chart.PlotArea.ActualHeight;

                // Adjust plot area coordinates manually using the retrieved actual values
                chart.PlotArea.AsILayoutable.X = actualX;
                chart.PlotArea.AsILayoutable.Y = actualY;

                // Save the presentation (handle unsupported format)
                try
                {
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (Exception)
                {
                    // Format not supported
                }
            }
        }
    }
}
