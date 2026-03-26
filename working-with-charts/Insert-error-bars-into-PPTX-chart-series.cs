using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace InsertErrorBars
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input PPTX file
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Access the first slide (adjust index if needed)
            ISlide slide = pres.Slides[0];

            // Assume the first shape on the slide is a chart
            IChart chart = slide.Shapes[0] as IChart;
            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
                return;
            }

            // Access the first series of the chart
            IChartSeries series = chart.ChartData.Series[0];

            // Configure X error bars
            series.ErrorBarsXFormat.Type = ErrorBarType.Plus;      // Show error bars in positive direction
            series.ErrorBarsXFormat.Value = 5f;                    // Fixed length of 5 points
            series.ErrorBarsXFormat.IsVisible = true;             // Make X error bars visible

            // Configure Y error bars
            series.ErrorBarsYFormat.Type = ErrorBarType.Both;     // Show error bars in both directions
            series.ErrorBarsYFormat.Value = 3f;                    // Fixed length of 3 points
            series.ErrorBarsYFormat.IsVisible = true;             // Make Y error bars visible

            // Save the modified presentation
            string outputPath = "output.pptx";
            pres.Save(outputPath, SaveFormat.Pptx);

            Console.WriteLine("Presentation saved with error bars: " + outputPath);
        }
    }
}