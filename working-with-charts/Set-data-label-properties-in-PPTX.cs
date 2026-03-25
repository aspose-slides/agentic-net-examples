using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartDataLabelDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = args.Length > 0 ? args[0] : "input.pptx";
            var outputPath = args.Length > 1 ? args[1] : "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Error: Input file '{inputPath}' not found.");
                return;
            }

            try
            {
                var pres = new Presentation(inputPath);
                var slide = pres.Slides[0];

                // Add a pie chart to the slide
                var chart = slide.Shapes.AddChart(ChartType.Pie, 50f, 50f, 400f, 300f);

                // Customize data label properties for the first series
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLeaderLines = true;
                chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;
                chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = false;
                chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = ", ";

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine($"Presentation saved to '{outputPath}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}