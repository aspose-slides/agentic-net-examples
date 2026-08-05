// -----------------------------------------------------------------------------
// Example: Check chart has trendline using C#
//
// Description:
// Demonstrates how to check whether a chart in a PowerPoint presentation
// contains any trendlines using Aspose.Slides for .NET. The example loads a
// PPTX file, inspects the first chart on the first slide, reports the presence
// of trendlines, and saves the presentation. This pattern can be used to
// automate validation of chart data visualizations in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Check, Chart, Trendline,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate verification that charts include trendlines.
// - Build C# tools for PowerPoint presentation analysis.
// - Integrate chart validation into .NET workflows.
// - Ensure presentation quality before publishing or further processing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartTrendLineChecker
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            Presentation pres = null;
            try
            {
                // Load presentation
                pres = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Assume first slide and first shape is a chart
            IChart chart = null;
            if (pres.Slides.Count > 0 && pres.Slides[0].Shapes.Count > 0)
            {
                chart = pres.Slides[0].Shapes[0] as IChart;
            }

            if (chart == null)
            {
                Console.WriteLine("No chart found in the presentation.");
            }
            else
            {
                bool hasTrendLines = HasTrendLines(chart);
                Console.WriteLine("Chart contains trend lines: " + hasTrendLines);
            }

            // Save presentation before exit
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
        }

        // Returns true if the specified chart contains at least one trend line
        public static bool HasTrendLines(IChart chart)
        {
            if (chart == null)
            {
                return false;
            }

            foreach (IChartSeries series in chart.ChartData.Series)
            {
                if (series.TrendLines.Count > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
