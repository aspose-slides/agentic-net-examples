using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace RetrieveSeriesFillColor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input file path
            string inputPath = "input.pptx";
            if (args.Length > 0)
            {
                inputPath = args[0];
            }

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Ensure there is at least one slide
                if (pres.Slides.Count == 0)
                {
                    Console.WriteLine("The presentation contains no slides.");
                }
                else
                {
                    // Attempt to get the first shape as a chart
                    IShape shape = pres.Slides[0].Shapes[0];
                    IChart chart = shape as IChart;

                    if (chart != null)
                    {
                        // Iterate through each series and retrieve its automatic fill color
                        IChartSeriesCollection seriesCollection = chart.ChartData.Series;
                        for (int i = 0; i < seriesCollection.Count; i++)
                        {
                            IChartSeries series = seriesCollection[i];
                            Color automaticColor = series.GetAutomaticSeriesColor();
                            Console.WriteLine($"Series {i} automatic fill color: {automaticColor}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No chart found on the first slide.");
                    }
                }

                // Save the presentation (even if unchanged) before exiting
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
    }
}