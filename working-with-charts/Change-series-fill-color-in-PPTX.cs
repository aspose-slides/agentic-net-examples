using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

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
        using (Presentation pres = new Presentation(inputPath))
        {
            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Assume the first shape is a chart
            IShape shape = slide.Shapes[0];
            IChart chart = shape as IChart;
            if (chart == null)
            {
                Console.WriteLine("The first shape is not a chart.");
                return;
            }

            // Change the fill color of the first series
            IChartSeries series = chart.ChartData.Series[0];
            series.Format.Fill.FillType = FillType.Solid;
            series.Format.Fill.SolidFillColor.Color = Color.Blue;

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }

        Console.WriteLine("Chart series color modified and saved to: " + outputPath);
    }
}