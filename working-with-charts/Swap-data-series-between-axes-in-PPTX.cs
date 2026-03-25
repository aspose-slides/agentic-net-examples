using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SwitchChartAxesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input and output file paths as command‑line arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: SwitchChartAxesExample <input.pptx> <output.pptx>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Error: Input file \"{inputPath}\" not found.");
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Assume the first slide contains the chart to modify
                ISlide slide = presentation.Slides[0];

                // Retrieve the first shape as a chart
                IChart chart = slide.Shapes[0] as IChart;
                if (chart == null)
                {
                    Console.WriteLine("Error: No chart found on the first slide.");
                    presentation.Dispose();
                    return;
                }

                // Switch data rows and columns (exchange X and Y axes)
                chart.ChartData.SwitchRowColumn();

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine($"Chart axes swapped successfully. Output saved to \"{outputPath}\".");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}