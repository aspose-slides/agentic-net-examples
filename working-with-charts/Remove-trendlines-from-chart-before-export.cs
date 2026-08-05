// -----------------------------------------------------------------------------
// Example: Remove trendlines from chart before export using C#
//
// Description:
// Demonstrates how to remove trendlines from a chart before exporting the
// chart as an image and saving the presentation using Aspose.Slides for .NET.
// The example creates a presentation, adds a clustered column chart, removes
// all trendlines from each series, exports the chart to PNG, and saves the
// presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Trendlines, Chart,
// Export, Image, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate removal of trendlines from charts prior to image export.
// - Build C# utilities for PowerPoint chart manipulation.
// - Generate or transform PPTX files with customized chart visuals.
// - Validate and prepare presentations before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace RemoveTrendLinesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for output files
            string presentationPath = "OutputPresentation.pptx";
            string chartImagePath = "ChartImage.png";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a clustered column chart with sample data to the first slide
                IChart chart = presentation.Slides[0].Shapes.AddChart(
                    ChartType.ClusteredColumn,
                    50f, 50f, 600f, 400f);

                // Remove all trend lines from each series in the chart
                foreach (IChartSeries series in chart.ChartData.Series)
                {
                    // Remove trend lines while any exist
                    while (series.TrendLines.Count > 0)
                    {
                        // Get the first trend line using enumerator
                        System.Collections.IEnumerator enumerator = series.TrendLines.GetEnumerator();
                        if (enumerator.MoveNext())
                        {
                            ITrendline trendline = (ITrendline)enumerator.Current;
                            series.TrendLines.Remove(trendline);
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                // Get chart image and save as PNG
                IImage chartImage = chart.GetImage();
                chartImage.Save(chartImagePath, Aspose.Slides.ImageFormat.Png);

                // Save the presentation
                presentation.Save(presentationPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
