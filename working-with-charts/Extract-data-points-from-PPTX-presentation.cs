using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartDataAggregation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // List to aggregate data point values
            List<object> aggregatedValues = new List<object>();

            // Iterate through slides
            foreach (ISlide slide in presentation.Slides)
            {
                // Iterate through shapes on the slide
                foreach (IShape shape in slide.Shapes)
                {
                    // Check if the shape is a chart
                    IChart chart = shape as IChart;
                    if (chart != null)
                    {
                        // Iterate through data points of the first series
                        if (chart.ChartData.Series.Count > 0)
                        {
                            foreach (IChartDataPoint dataPoint in chart.ChartData.Series[0].DataPoints)
                            {
                                // Add the data point value to the aggregation list
                                aggregatedValues.Add(dataPoint.Value.Data);
                            }
                        }
                    }
                }
            }

            // Example: output the count of aggregated data points
            Console.WriteLine("Total data points aggregated: " + aggregatedValues.Count);

            // Save the presentation before exiting
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}