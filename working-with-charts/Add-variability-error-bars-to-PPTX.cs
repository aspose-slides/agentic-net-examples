using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ErrorBarsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: ErrorBarsExample <input-pptx-path>");
                return;
            }

            string inputPath = args[0];
            if (!System.IO.File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                Presentation pres = new Presentation(inputPath);
                ISlide slide = pres.Slides[0];

                // Add a scatter chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 50f, 50f, 500f, 400f);

                // Access the first series and configure error bars
                IChartSeries series = chart.ChartData.Series[0];
                series.ErrorBarsXFormat.Type = ErrorBarType.Both;
                series.ErrorBarsXFormat.Value = 0.5f;
                series.ErrorBarsYFormat.Type = ErrorBarType.Both;
                series.ErrorBarsYFormat.Value = 0.5f;

                string outputPath = "output_with_errorbars.pptx";
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}