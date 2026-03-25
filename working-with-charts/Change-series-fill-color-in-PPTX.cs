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
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found.");
                return;
            }

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Assume the first shape on the slide is a chart
                IShape shape = slide.Shapes[0];
                IChart chart = shape as IChart;

                if (chart != null)
                {
                    // Access the first series of the chart
                    IChartSeries series = chart.ChartData.Series[0];

                    // Change the fill type to solid and set a new color (e.g., Red)
                    series.Format.Fill.FillType = FillType.Solid;
                    series.Format.Fill.SolidFillColor.Color = Color.FromArgb(255, 0, 0);
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}