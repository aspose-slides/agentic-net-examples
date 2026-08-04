// -----------------------------------------------------------------------------
// Example: Remove error bars from chart before PNG using C#
//
// Description:
// Demonstrates how to remove error bars from all chart series in a PowerPoint
// presentation before exporting a slide to PNG using C# and Aspose.Slides for .NET.
// The example loads a PPTX file, hides X and Y error bars for each series in
// every chart, saves the modified presentation, and renders the first slide as
// a PNG image.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Remove, Error Bars, Chart,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Remove error bars from charts in existing presentations prior to image export.
// - Automate preparation of PPTX files for publishing or sharing as PNGs.
// - Integrate chart cleanup steps into .NET applications that generate or modify slides.
// - Ensure visual consistency of exported slide images by eliminating unwanted error bars.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace RemoveErrorBars
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPresentationPath = "output.pptx";
            string outputImagePath = "slide0.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                        // Iterate through all shapes on the slide to find charts
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.Charts.IChart chart = slide.Shapes[shapeIndex] as Aspose.Slides.Charts.IChart;
                            if (chart != null)
                            {
                                // Remove error bars from each series in the chart
                                for (int seriesIndex = 0; seriesIndex < chart.ChartData.Series.Count; seriesIndex++)
                                {
                                    Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[seriesIndex];

                                    // Hide X error bars if they exist
                                    if (series.ErrorBarsXFormat != null)
                                    {
                                        series.ErrorBarsXFormat.IsVisible = false;
                                    }

                                    // Hide Y error bars if they exist
                                    if (series.ErrorBarsYFormat != null)
                                    {
                                        series.ErrorBarsYFormat.IsVisible = false;
                                    }
                                }
                            }
                        }

                        // Convert the current slide to PNG
                        using (Aspose.Slides.IImage image = slide.GetImage())
                        {
                            image.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
                        }
                    }

                    // Save the modified presentation before exiting
                    pres.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
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
