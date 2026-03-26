using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RetrieveSeriesColor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the presentation
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Access the first slide
                var slide = presentation.Slides[0];

                // Assume the first shape is a chart
                var shape = slide.Shapes[0];
                var chart = shape as Aspose.Slides.Charts.IChart;

                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                    return;
                }

                // Iterate through each series and retrieve its automatic fill color
                for (int i = 0; i < chart.ChartData.Series.Count; i++)
                {
                    var series = chart.ChartData.Series[i];
                    var autoColor = series.GetAutomaticSeriesColor();
                    Console.WriteLine($"Series {i} automatic color: {autoColor}");
                }

                // Save the presentation before exiting
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine($"Presentation saved to {outputPath}");
            }
        }
    }
}