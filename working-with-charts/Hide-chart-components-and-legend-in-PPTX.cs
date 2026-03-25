using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HideChartComponents
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
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Retrieve the first chart on the slide (adjust indices as needed)
            Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;

            if (chart != null)
            {
                // Hide legend entirely
                chart.HasLegend = false;

                // Hide selected data label components for the first series
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLegendKey = false;
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = false;
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowCategoryName = false;
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowSeriesName = false;
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = false;
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowBubbleSize = false;
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            pres.Dispose();

            Console.WriteLine("Presentation saved to " + outputPath);
        }
    }
}