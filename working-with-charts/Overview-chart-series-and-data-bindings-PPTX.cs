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
            string inputPath = "input.pptx";
            string outputPath = "ChartSeriesOverview_out.pptx";

            if (File.Exists(inputPath) == false)
            {
                Console.WriteLine("Input PPTX file not found: " + inputPath);
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];
                        Console.WriteLine("Slide " + (slideIndex + 1) + ":");

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Process only chart shapes
                            IChart chart = shape as IChart;
                            if (chart == null)
                            {
                                continue;
                            }

                            Console.WriteLine("  Chart Type: " + chart.Type);
                            IChartSeriesCollection seriesCollection = chart.ChartData.Series;

                            // Overview of each series
                            for (int seriesIdx = 0; seriesIdx < seriesCollection.Count; seriesIdx++)
                            {
                                IChartSeries series = seriesCollection[seriesIdx];
                                Console.WriteLine("    Series " + (seriesIdx + 1) + ":");
                                Console.WriteLine("      Name: " + (series.Name != null ? series.Name.ToString() : "N/A"));
                                Console.WriteLine("      Type: " + series.Type);
                                Console.WriteLine("      Order: " + series.Order);
                                Console.WriteLine("      Number Format (Values): " + series.NumberFormatOfValues);
                                Console.WriteLine("      Number Format (X Values): " + series.NumberFormatOfXValues);
                                Console.WriteLine("      Number Format (Y Values): " + series.NumberFormatOfYValues);
                                Console.WriteLine("      Data Points Count: " + series.DataPoints.Count);

                                // Simple data point overview (value count)
                                for (int dpIdx = 0; dpIdx < series.DataPoints.Count; dpIdx++)
                                {
                                    IChartDataPoint dataPoint = series.DataPoints[dpIdx];
                                    // Attempt to retrieve the cell value as string if possible
                                    string cellValue = "N/A";
                                    try
                                    {
                                        if (dataPoint.Value != null)
                                        {
                                            cellValue = dataPoint.Value.ToString();
                                        }
                                    }
                                    catch
                                    {
                                        // Ignore any errors retrieving the value
                                    }
                                    Console.WriteLine("        Data Point " + (dpIdx + 1) + ": Value = " + cellValue);
                                }
                            }
                        }
                    }

                    // Save the presentation (unchanged) before exiting
                    pres.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved to: " + outputPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while processing the presentation:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}