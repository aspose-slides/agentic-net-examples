using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ApplyChartThemeExample
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

            // Load the presentation from the input file
            Presentation pres = new Presentation(inputPath);

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);

            // Apply automatic series colors based on the current theme
            for (int i = 0; i < chart.ChartData.Series.Count; i++)
            {
                chart.ChartData.Series[i].GetAutomaticSeriesColor();
            }

            // Save the updated presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}