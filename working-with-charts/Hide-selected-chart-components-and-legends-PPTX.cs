using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace HideChartComponents
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input and output file paths as arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: HideChartComponents <input.pptx> <output.pptx>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Assume the first slide contains the chart
            ISlide slide = pres.Slides[0];

            // Assume the first shape on the slide is a chart
            IChart chart = slide.Shapes[0] as IChart;
            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
                pres.Dispose();
                return;
            }

            // Hide various data label components for the first series
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLegendKey = false;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = false;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowCategoryName = false;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowSeriesName = false;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = false;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowBubbleSize = false;

            // Hide the legend entirely
            chart.HasLegend = false;

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
    }
}