using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DataLabelCustomization
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            try
            {
                // Load existing presentation
                Presentation pres = new Presentation(inputPath);

                // Get first slide
                ISlide slide = pres.Slides[0];

                // Add a Pie chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

                // Customize data label properties
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLeaderLines = true;
                chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;
                chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = false;
                chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = ", ";

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}