using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ChartDataExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

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
                    Aspose.Slides.Charts.IChart chart = slide.Shapes[shapeIndex] as Aspose.Slides.Charts.IChart;
                    if (chart != null)
                    {
                        // Iterate through all series in the chart
                        for (int seriesIndex = 0; seriesIndex < chart.ChartData.Series.Count; seriesIndex++)
                        {
                            // Iterate through all data points in the series
                            foreach (Aspose.Slides.Charts.IChartDataPoint dataPoint in chart.ChartData.Series[seriesIndex].DataPoints)
                            {
                                object rawValue = dataPoint.Value.Data;
                                double numericValue;

                                if (rawValue is double)
                                {
                                    numericValue = (double)rawValue;
                                }
                                else if (rawValue is int)
                                {
                                    numericValue = Convert.ToDouble(rawValue);
                                }
                                else if (rawValue != null && double.TryParse(rawValue.ToString(), out numericValue))
                                {
                                    // parsed successfully
                                }
                                else
                                {
                                    // Non-numeric value; skip
                                    continue;
                                }

                                allValues.Add(numericValue);
                            }
                        }
                    }
                }
            }

            // Example aggregation: compute sum and count
            double sum = 0;
            foreach (double value in allValues)
            {
                sum += value;
            }

            Console.WriteLine("Total data points extracted: " + allValues.Count);
            Console.WriteLine("Sum of all data point values: " + sum);

            // Save the (unchanged) presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}