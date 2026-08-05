// -----------------------------------------------------------------------------
// Example: Skip charts without plot area for trendlines using C#
//
// Description:
// Demonstrates how to safely add linear trend lines to chart series only when
// the chart contains a plot area and supports trend lines, using Aspose.Slides
// for .NET. The example loads a PPTX file, iterates through its slides and
// shapes, skips charts lacking a plot area, and adds a linear trend line to
// each series of supported chart types before saving the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Skip, Charts, Plot Area, Trendlines,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Add trend lines to charts in bulk while avoiding errors on charts without plot areas.
// - Automate PowerPoint chart enhancements in .NET applications.
// - Validate and preprocess PPTX files before publishing or further analysis.
// - Integrate chart trend line logic into custom presentation workflows.
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
            // Path to the input presentation
            string inputPath = "input.pptx";
            // Path to the output presentation
            string outputPath = "output.pptx";

            // Verify that the input file exists
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
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            // Attempt to cast the shape to a chart
                            IChart chart = slide.Shapes[shapeIndex] as IChart;
                            if (chart == null)
                            {
                                continue; // Not a chart, skip
                            }

                            // Skip charts without a plot area to avoid errors
                            if (chart.PlotArea == null)
                            {
                                continue;
                            }

                            // Check if the chart type supports trend lines
                            if (!ChartTypeCharacterizer.HasSeriesTrendLines(chart.Type))
                            {
                                continue;
                            }

                            // Add a linear trend line to each series
                            for (int seriesIndex = 0; seriesIndex < chart.ChartData.Series.Count; seriesIndex++)
                            {
                                IChartSeries series = chart.ChartData.Series[seriesIndex];
                                // Add a linear trend line
                                series.TrendLines.Add(TrendlineType.Linear);
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported file formats or other errors
                // Format not supported or other processing error
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
