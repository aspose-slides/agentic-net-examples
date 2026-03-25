using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace RetrieveSeriesColor
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Assume the first slide contains the chart
                ISlide slide = presentation.Slides[0];

                // Find the first chart shape on the slide
                IChart chart = null;
                foreach (IShape shape in slide.Shapes)
                {
                    chart = shape as IChart;
                    if (chart != null)
                        break;
                }

                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                }
                else
                {
                    // Iterate through each series and retrieve its automatic fill color
                    for (int i = 0; i < chart.ChartData.Series.Count; i++)
                    {
                        IChartSeries series = chart.ChartData.Series[i];
                        Color autoColor = series.GetAutomaticSeriesColor();
                        Console.WriteLine($"Series {i} automatic color: ARGB({autoColor.A}, {autoColor.R}, {autoColor.G}, {autoColor.B})");
                    }
                }

                // Save the presentation (even if unchanged) before exiting
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}