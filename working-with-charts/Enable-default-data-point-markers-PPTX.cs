using System;
using System.IO;
using Aspose.Slides.Export;

namespace EnableDefaultMarkers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
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
                        // Check if the shape is a chart
                        Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                        if (chart != null)
                        {
                            // Enable default markers for each series in the chart
                            foreach (Aspose.Slides.Charts.IChartSeries series in chart.ChartData.Series)
                            {
                                series.Marker.Size = 5; // Set marker size
                                series.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Circle; // Set marker style
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