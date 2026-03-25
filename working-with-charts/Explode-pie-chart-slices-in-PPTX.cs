using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExplodePieChartSlices
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input PPTX file path as first argument
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: ExplodePieChartSlices <input-pptx-path>");
                return;
            }

            string inputPath = args[0];
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Error: File not found - {inputPath}");
                return;
            }

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Iterate through all slides
                foreach (ISlide slide in pres.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (IShape shape in slide.Shapes)
                    {
                        // Process only chart shapes
                        IChart chart = shape as IChart;
                        if (chart == null)
                            continue;

                        // Work only with pie or doughnut chart types
                        ChartType chartType = chart.Type;
                        bool isPie = chartType == ChartType.Pie ||
                                     chartType == ChartType.ExplodedPie ||
                                     chartType == ChartType.Pie3D ||
                                     chartType == ChartType.ExplodedPie3D;
                        bool isDoughnut = chartType == ChartType.Doughnut ||
                                          chartType == ChartType.ExplodedDoughnut;

                        if (!isPie && !isDoughnut)
                            continue;

                        // Iterate through each series in the chart
                        foreach (IChartSeries series in chart.ChartData.Series)
                        {
                            // Iterate through each data point (slice) in the series
                            int pointIndex = 0;
                            foreach (IChartDataPoint point in series.DataPoints)
                            {
                                // Example: explode every second slice by 20%
                                if (pointIndex % 2 == 0)
                                {
                                    point.Explosion = 20; // distance as percentage of pie diameter
                                }
                                else
                                {
                                    point.Explosion = 0;
                                }
                                pointIndex++;
                            }
                        }
                    }
                }

                // Save the modified presentation
                string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), "Exploded_" + Path.GetFileName(inputPath));
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine($"Presentation saved to: {outputPath}");
            }
        }
    }
}