using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartLegendPositionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input and output file paths as arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ChartLegendPositionExample <input.pptx> <output.pptx>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            try
            {
                // Load existing presentation
                Presentation presentation = new Presentation(inputPath);

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart with sample size and position
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 350f);

                // Set custom legend position and size (fraction of chart dimensions)
                chart.Legend.X = 0.7f;      // 70% from left
                chart.Legend.Y = 0.1f;      // 10% from top
                chart.Legend.Width = 0.2f;  // 20% of chart width
                chart.Legend.Height = 0.2f; // 20% of chart height

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}