using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                var presentation = new Presentation(inputPath);

                // Add a clustered column chart
                var chart = (Chart)presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);
                chart.ValidateChartLayout();

                // Get actual plot area dimensions
                var actualWidth = chart.PlotArea.ActualWidth;
                var actualHeight = chart.PlotArea.ActualHeight;

                // Resize plot area to 80% of its actual size (custom dimensions)
                chart.PlotArea.Width = (float)(actualWidth * 0.8);
                chart.PlotArea.Height = (float)(actualHeight * 0.8);

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}