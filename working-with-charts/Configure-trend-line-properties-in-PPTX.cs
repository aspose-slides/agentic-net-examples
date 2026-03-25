using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace TrendlineExample
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
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Assume the first shape on the first slide is a chart
            ISlide slide = pres.Slides[0];
            IShape shape = slide.Shapes[0];
            IChart chart = shape as IChart;
            if (chart == null)
            {
                Console.WriteLine("Error: No chart found on the first slide.");
                pres.Save(outputPath, SaveFormat.Pptx);
                return;
            }

            // Add a linear trendline to the first series
            ITrendline trendline = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
            // Configure trendline display options
            trendline.DisplayEquation = false;
            trendline.DisplayRSquaredValue = false;
            // Set line format to solid red
            trendline.Format.Line.FillFormat.FillType = FillType.Solid;
            trendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}