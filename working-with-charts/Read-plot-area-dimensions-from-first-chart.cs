// -----------------------------------------------------------------------------
// Example: Read plot area dimensions from first chart using C#
//
// Description:
// Demonstrates how to read plot area dimensions from the first chart on the
// first slide of a PowerPoint presentation using C# and Aspose.Slides for .NET.
// The example loads a presentation, locates the first chart, validates its
// layout, retrieves the actual plot area coordinates and size, outputs them,
// and saves the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Read, Plot Area, Dimensions,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of plot area dimensions from charts in PPTX files.
// - Build C# utilities for PowerPoint presentation analysis.
// - Validate chart layout during PPTX generation or transformation.
// - Integrate plot area data retrieval into .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    ISlide slide = pres.Slides[0];
                    IChart chart = null;

                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is IChart)
                        {
                            chart = (IChart)shape;
                            break;
                        }
                    }

                    if (chart != null)
                    {
                        // Ensure actual layout values are calculated
                        chart.ValidateChartLayout();

                        IChartPlotArea plotArea = chart.PlotArea;

                        float actualX = plotArea.ActualX;
                        float actualY = plotArea.ActualY;
                        float actualWidth = plotArea.ActualWidth;
                        float actualHeight = plotArea.ActualHeight;

                        Console.WriteLine($"Plot Area Dimensions:");
                        Console.WriteLine($"X: {actualX}");
                        Console.WriteLine($"Y: {actualY}");
                        Console.WriteLine($"Width: {actualWidth}");
                        Console.WriteLine($"Height: {actualHeight}");
                    }
                    else
                    {
                        Console.WriteLine("No chart found on the first slide.");
                    }

                    // Save the presentation before exiting
                    pres.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
