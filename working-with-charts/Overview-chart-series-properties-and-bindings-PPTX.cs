using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartSeriesOverview
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string inputFile = Path.Combine(dataDir, "input.pptx");
            string outputFile = Path.Combine(dataDir, "output_overview.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file not found: " + inputFile);
                return;
            }

            // Load the presentation
            Presentation pres = new Presentation(inputFile);

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Assume the first shape is a chart
            IChart chart = slide.Shapes[0] as IChart;
            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
                pres.Dispose();
                return;
            }

            // Get the workbook that stores chart data
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Iterate through each series in the chart
            for (int seriesIndex = 0; seriesIndex < chart.ChartData.Series.Count; seriesIndex++)
            {
                IChartSeries series = chart.ChartData.Series[seriesIndex];

                // Retrieve the series name using AsLiteralString (fix for IStringChartValue)
                string seriesName = series.Name.AsLiteralString;

                Console.WriteLine("Series {0}:", seriesIndex);
                Console.WriteLine("  Name                : " + seriesName);
                Console.WriteLine("  Type                : " + series.Type);
                Console.WriteLine("  Order               : " + series.Order);
                Console.WriteLine("  NumberFormatOfValues: " + series.NumberFormatOfValues);
                Console.WriteLine("  PlotOnSecondAxis    : " + series.PlotOnSecondAxis);
                Console.WriteLine("  IsColorVaried       : " + series.IsColorVaried);
                Console.WriteLine("  Overlap (group)     : " + series.ParentSeriesGroup.Overlap);
                Console.WriteLine("  Data Points Count   : " + series.DataPoints.Count);

                // Iterate through data points of the series
                for (int pointIndex = 0; pointIndex < series.DataPoints.Count; pointIndex++)
                {
                    IChartDataPoint dataPoint = series.DataPoints[pointIndex];
                    object value = dataPoint.Value.Data;
                    Console.WriteLine("    DataPoint {0} Value: " + value, pointIndex);
                }

                Console.WriteLine();
            }

            // Save the presentation (even if unchanged) before exiting
            pres.Save(outputFile, SaveFormat.Pptx);
            pres.Dispose();

            Console.WriteLine("Overview completed. Output saved to: " + outputFile);
        }
    }
}