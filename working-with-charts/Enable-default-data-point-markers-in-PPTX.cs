using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace EnableDefaultMarkers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input and output file paths as arguments
            if (args == null || args.Length < 2)
            {
                Console.WriteLine("Usage: EnableDefaultMarkers <input.pptx> <output.pptx>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Iterate through all slides
            int slideCount = presentation.Slides.Count;
            for (int i = 0; i < slideCount; i++)
            {
                ISlide slide = presentation.Slides[i];

                // Iterate through all shapes on the slide
                int shapeCount = slide.Shapes.Count;
                for (int j = 0; j < shapeCount; j++)
                {
                    // Check if the shape is a chart
                    IChart chart = slide.Shapes[j] as IChart;
                    if (chart != null)
                    {
                        // Enable default markers for each series in the chart
                        int seriesCount = chart.ChartData.Series.Count;
                        for (int k = 0; k < seriesCount; k++)
                        {
                            IChartSeries series = chart.ChartData.Series[k];
                            series.Marker.Size = 5; // Default marker size
                            series.Marker.Symbol = MarkerStyleType.Circle; // Default marker symbol
                        }
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}