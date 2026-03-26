using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartUpdateExample
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
            using (Presentation pres = new Presentation(inputPath))
            {
                // Assume the first shape on the first slide is a chart
                IChart chart = pres.Slides[0].Shapes[0] as IChart;
                if (chart != null)
                {
                    // Update data points in the first series
                    chart.ChartData.Series[0].DataPoints[0].Value.Data = 123.45;
                    chart.ChartData.Series[0].DataPoints[1].Value.Data = 67.89;
                }

                // Save the updated presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}