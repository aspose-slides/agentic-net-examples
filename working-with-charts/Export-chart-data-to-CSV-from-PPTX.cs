using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExportChartDataToCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            // Validate input arguments
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please provide the path to the input PPTX file as a command-line argument.");
                return;
            }

            string inputPath = args[0];
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Output CSV file path
            string csvPath = Path.Combine(Path.GetDirectoryName(inputPath), "ChartData.csv");

            // Open the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Prepare CSV writer
                using (StreamWriter writer = new StreamWriter(csvPath, false))
                {
                    // Write CSV header
                    writer.WriteLine("SlideIndex,ChartIndex,DataRange");

                    // Iterate through slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];
                        int chartIndex = 0;

                        // Iterate through shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];
                            IChart chart = shape as IChart;
                            if (chart != null)
                            {
                                // Get chart data range
                                IChartData chartData = chart.ChartData;
                                string range = chartData.GetRange();

                                // Write CSV line
                                writer.WriteLine($"{slideIndex + 1},{chartIndex + 1},\"{range}\"");
                                chartIndex++;
                            }
                        }
                    }
                }

                // Save the presentation (required by lifecycle rule)
                string outputPptx = Path.Combine(Path.GetDirectoryName(inputPath), "ProcessedPresentation.pptx");
                pres.Save(outputPptx, SaveFormat.Pptx);
            }

            Console.WriteLine($"Chart data exported to: {csvPath}");
        }
    }
}