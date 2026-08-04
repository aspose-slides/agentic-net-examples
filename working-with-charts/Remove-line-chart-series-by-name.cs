// -----------------------------------------------------------------------------
// Example: Remove line chart series by name using C#
//
// Description:
// Demonstrates how to remove a specific line chart series identified by its name
// from a PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// loads a PPTX file, locates the first chart on the first slide, searches for a
// series with a given name, removes it if present, and saves the updated file.
// This pattern can be used to automate chart data cleanup or dynamic presentation
// modifications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Line, Chart, Series, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate removal of unwanted line chart series by name.
// - Build C# utilities for PowerPoint chart manipulation.
// - Update or clean up PPTX files in .NET applications.
// - Integrate chart series management into presentation workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace RemoveLineChartSeriesByName
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string dataDir = @"./Data/";
            string inputFile = "InputChart.pptx";
            string outputFile = "OutputChart.pptx";
            string inputPath = Path.Combine(dataDir, inputFile);
            string outputPath = Path.Combine(dataDir, outputFile);

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Access the first shape and cast it to a chart
                    IShape shape = slide.Shapes[0];
                    IChart chart = shape as IChart;

                    if (chart != null && chart.ChartData.Series.Count > 0)
                    {
                        // Name of the series to remove
                        string targetSeriesName = "SeriesToRemove";

                        // Find the series with the matching name
                        IChartSeries seriesToRemove = null;
                        foreach (IChartSeries series in chart.ChartData.Series)
                        {
                            // Convert IStringChartValue to plain string before comparison
                            string seriesName = series.Name.AsLiteralString;
                            if (seriesName == targetSeriesName)
                            {
                                seriesToRemove = series;
                                break;
                            }
                        }

                        // Remove the series if found
                        if (seriesToRemove != null)
                        {
                            chart.ChartData.Series.Remove(seriesToRemove);
                            Console.WriteLine("Series removed: " + targetSeriesName);
                        }
                        else
                        {
                            Console.WriteLine("Series not found: " + targetSeriesName);
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
