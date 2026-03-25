using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Determine input file path
        string inputPath = "input.pptx";
        if (args.Length > 0)
        {
            inputPath = args[0];
        }

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
        {
            // Attempt to get the first shape as a chart
            Aspose.Slides.IShape shape = pres.Slides[0].Shapes[0];
            Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                return;
            }

            // Calculate actual layout values for the chart
            chart.ValidateChartLayout();

            // Retrieve actual position and size of the plot area
            Aspose.Slides.Charts.IChartPlotArea plotArea = chart.PlotArea;
            float actualX = plotArea.ActualX;
            float actualY = plotArea.ActualY;
            float actualWidth = plotArea.ActualWidth;
            float actualHeight = plotArea.ActualHeight;

            Console.WriteLine($"PlotArea Actual Position: X={actualX}, Y={actualY}, Width={actualWidth}, Height={actualHeight}");

            // Save the modified presentation
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}