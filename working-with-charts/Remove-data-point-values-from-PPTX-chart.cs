using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace RemoveChartDataPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to the input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Cast the shape to a chart if possible
                        Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                        if (chart != null)
                        {
                            // Example: remove the first data point from the first series
                            if (chart.ChartData.Series.Count > 0)
                            {
                                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
                                if (series.DataPoints.Count > 0)
                                {
                                    // Remove data point at index 0
                                    series.DataPoints.RemoveAt(0);
                                }
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}