// -----------------------------------------------------------------------------
// Example: Check if chart has trendline using C#
//
// Description:
// Demonstrates how to determine whether a chart in a PowerPoint presentation
// contains any trendlines using Aspose.Slides for .NET. The example loads a
// presentation, locates the first chart on the first slide, checks each series
// for trendlines, outputs the result, and saves the presentation.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Chart, Trendline, Presentation Processing,
// Office Automation, .NET
//
// Use Cases:
// - Verify presence of trendlines in charts before publishing.
// - Automate quality checks for PowerPoint reports.
// - Integrate chart analysis into .NET applications.
// - Build tools that process PPTX files for data validation.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartTrendLineChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            Presentation pres = null;
            try
            {
                pres = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format exception
                // Format not supported
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            if (pres.Slides.Count == 0)
            {
                Console.WriteLine("Presentation contains no slides.");
                pres.Save(outputPath, SaveFormat.Pptx);
                return;
            }

            ISlide slide = pres.Slides[0];
            IChart chart = null;

            // Find first chart shape on the slide
            foreach (IShape shape in slide.Shapes)
            {
                chart = shape as IChart;
                if (chart != null)
                {
                    break;
                }
            }

            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
                pres.Save(outputPath, SaveFormat.Pptx);
                return;
            }

            bool hasTrendLine = ChartHasTrendLines(chart);
            Console.WriteLine("Chart contains trend line: " + hasTrendLine);

            // Save presentation before exit
            pres.Save(outputPath, SaveFormat.Pptx);
        }

        public static bool ChartHasTrendLines(IChart chart)
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
