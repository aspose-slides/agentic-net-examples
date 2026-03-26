using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SwapChartAxes
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the presentation
            using var presentation = new Presentation(inputPath);

            // Assume the first shape on the first slide is a chart
            var chart = presentation.Slides[0].Shapes[0] as IChart;
            if (chart != null)
            {
                // Swap the data series between the X and Y axes
                chart.ChartData.SwitchRowColumn();
            }
            else
            {
                Console.WriteLine("No chart found on the first slide.");
                return;
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            Console.WriteLine($"Presentation saved to: {outputPath}");
        }
    }
}