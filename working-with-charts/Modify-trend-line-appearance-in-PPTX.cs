using System;
using System.IO;
using Aspose.Slides.Export;
using System.Drawing;

namespace TrendlineDemo
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
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Access the first slide and first shape (assumed to be a chart)
                Aspose.Slides.ISlide slide = pres.Slides[0];
                Aspose.Slides.IShape shape = slide.Shapes[0];
                Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;

                // Ensure the shape is a chart and has at least one series
                if (chart != null && chart.ChartData.Series.Count > 0)
                {
                    // Add a linear trendline to the first series
                    Aspose.Slides.Charts.ITrendline trendline = chart.ChartData.Series[0].TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Linear);

                    // Modify visual attributes of the trendline
                    trendline.DisplayEquation = false;
                    trendline.DisplayRSquaredValue = false;
                    trendline.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    trendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}