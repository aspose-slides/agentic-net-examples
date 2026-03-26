using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace PieChartExplosionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Retrieve the first chart on the slide
            IChart chart = slide.Shapes[0] as IChart;
            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
                return;
            }

            // Access the first series of the pie chart
            IChartSeries series = chart.ChartData.Series[0];

            // Offset each slice (explode) by setting the Explosion property
            for (int i = 0; i < series.DataPoints.Count; i++)
            {
                // Set explosion percentage (e.g., 20% of the pie diameter)
                series.DataPoints[i].Explosion = 20;
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}