using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartPlotAreaDimensions
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found.");
                return;
            }

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Add a chart to the first slide (or retrieve an existing one)
            Aspose.Slides.Charts.Chart chart = (Aspose.Slides.Charts.Chart)presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);

            // Validate layout to get actual plot area values
            chart.ValidateChartLayout();

            double x = chart.PlotArea.ActualX;
            double y = chart.PlotArea.ActualY;
            double width = chart.PlotArea.ActualWidth;
            double height = chart.PlotArea.ActualHeight;

            Console.WriteLine($"Plot Area Position: ({x}, {y})");
            Console.WriteLine($"Plot Area Size: Width = {width}, Height = {height}");

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}