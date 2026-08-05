// -----------------------------------------------------------------------------
// Example: Read plot area dimensions from PPTX chart using C#
//
// Description:
// Demonstrates how to read the plot area dimensions (X, Y, Width, Height) 
// from the first chart on the first slide of a PPTX file using Aspose.Slides 
// for .NET. The example validates the chart layout, outputs the actual plot 
// area values to the console, and saves the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Read, Plot Area, Dimensions, 
// Chart Layout Validation, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of plot area dimensions from PPTX charts.
// - Build C# utilities for PowerPoint chart analysis.
// - Integrate chart dimension validation into .NET applications.
// - Verify chart layout before further processing or publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (var pres = new Presentation(inputPath))
            {
                // Ensure there is at least one slide
                if (pres.Slides.Count == 0)
                {
                    Console.WriteLine("Presentation contains no slides.");
                    return;
                }

                // Locate the first chart on the first slide
                Aspose.Slides.Charts.IChart chart = null;
                foreach (var shape in pres.Slides[0].Shapes)
                {
                    if (shape is Aspose.Slides.Charts.IChart)
                    {
                        chart = (Aspose.Slides.Charts.IChart)shape;
                        break;
                    }
                }

                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                }
                else
                {
                    // Calculate actual layout values
                    chart.ValidateChartLayout();

                    var x = chart.PlotArea.ActualX;
                    var y = chart.PlotArea.ActualY;
                    var width = chart.PlotArea.ActualWidth;
                    var height = chart.PlotArea.ActualHeight;

                    // Output plot area dimensions
                    Console.WriteLine($"Plot Area - X: {x}, Y: {y}, Width: {width}, Height: {height}");
                }

                // Save the presentation before exiting
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine($"An error occurred: {ex.Message}");
            // Format not supported comment
            // Note: If the file format is not supported, an exception will be caught here.
        }
    }
}
