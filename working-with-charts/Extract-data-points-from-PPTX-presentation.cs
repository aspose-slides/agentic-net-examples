using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartDataExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path (can be passed as first argument)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Collection to hold all numeric data point values
            List<double> allValues = new List<double>();

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    // Use the chart-data-point-index rule pattern to get a chart
                    Aspose.Slides.Charts.IChart chart = slide.Shapes[shapeIndex] as Aspose.Slides.Charts.IChart;
                    if (chart != null)
                    {
                        // Iterate through each series in the chart
                        for (int seriesIndex = 0; seriesIndex < chart.ChartData.Series.Count; seriesIndex++)
                        {
                            // Iterate through each data point in the series
                            foreach (Aspose.Slides.Charts.IChartDataPoint dataPoint in chart.ChartData.Series[seriesIndex].DataPoints)
                            {
                                // Extract the underlying value (if numeric) and add to the list
                                object rawValue = dataPoint.Value.Data;
                                if (rawValue is double)
                                {
                                    allValues.Add((double)rawValue);
                                }
                                else if (rawValue is int)
                                {
                                    allValues.Add(Convert.ToDouble(rawValue));
                                }
                                // Non‑numeric values are ignored
                            }
                        }
                    }
                }
            }

            // Example aggregation: compute total count and sum of all values
            double sum = 0;
            foreach (double value in allValues)
            {
                sum += value;
            }

            Console.WriteLine("Total data points extracted: " + allValues.Count);
            Console.WriteLine("Sum of numeric values: " + sum);

            // Save the (potentially unchanged) presentation before exiting
            string outputPath = "output.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}