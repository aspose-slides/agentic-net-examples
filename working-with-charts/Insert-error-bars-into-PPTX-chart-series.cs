using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace InsertErrorBarsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input and output file paths as arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: InsertErrorBarsExample <input.pptx> <output.pptx>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Access the first slide (adjust index as needed)
            ISlide slide = pres.Slides[0];

            // Find the first chart on the slide (adjust logic if necessary)
            IChart chart = null;
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is IChart)
                {
                    chart = (IChart)shape;
                    break;
                }
            }

            if (chart == null)
            {
                Console.WriteLine("Error: No chart found on the first slide.");
                return;
            }

            // Access the first series of the chart
            IChartSeries series = chart.ChartData.Series[0];

            // Configure X error bars
            series.ErrorBarsXFormat.Type = ErrorBarType.Both;
            series.ErrorBarsXFormat.Value = 0.5f; // Fixed value for X error bars
            series.ErrorBarsXFormat.IsVisible = true;

            // Configure Y error bars
            series.ErrorBarsYFormat.Type = ErrorBarType.Both;
            series.ErrorBarsYFormat.Value = 0.5f; // Fixed value for Y error bars
            series.ErrorBarsYFormat.IsVisible = true;

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}