using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

namespace ChartSeriesColorModifier
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
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation pres = new Presentation(inputPath);
            // Access the first slide
            ISlide slide = pres.Slides[0];
            // Assume the first shape is a chart
            IChart chart = slide.Shapes[0] as IChart;
            if (chart != null)
            {
                // Modify the fill color of the first series
                IChartSeries series = chart.ChartData.Series[0];
                series.Format.Fill.FillType = FillType.Solid;
                series.Format.Fill.SolidFillColor.Color = Color.FromArgb(255, 0, 0, 255); // Blue
            }

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            // Clean up
            pres.Dispose();

            Console.WriteLine("Chart series color modified and saved to: " + outputPath);
        }
    }
}