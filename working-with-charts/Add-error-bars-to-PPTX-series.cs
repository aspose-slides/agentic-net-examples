using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddErrorBarsExample
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
            Presentation presentation = new Presentation(inputPath);

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Assume the first shape on the slide is a chart
            IChart chart = slide.Shapes[0] as IChart;
            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
                presentation.Dispose();
                return;
            }

            // Access the first series of the chart
            IChartSeries series = chart.ChartData.Series[0];

            // Configure X error bars
            series.ErrorBarsXFormat.Type = ErrorBarType.Plus;
            series.ErrorBarsXFormat.Value = 0.5f;

            // Configure Y error bars
            series.ErrorBarsYFormat.Type = ErrorBarType.Plus;
            series.ErrorBarsYFormat.Value = 0.5f;

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}