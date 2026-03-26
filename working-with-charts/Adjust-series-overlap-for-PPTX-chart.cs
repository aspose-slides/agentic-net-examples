using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation from the input file
        Presentation presentation = new Presentation(inputPath);

        // Ensure the presentation has at least one slide
        if (presentation.Slides.Count == 0)
        {
            Console.WriteLine("The presentation contains no slides.");
            presentation.Dispose();
            return;
        }

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Retrieve the series collection from the chart
        IChartSeriesCollection series = chart.ChartData.Series;

        // Set the series overlap if it is currently the default value (0)
        if (series[0].Overlap == 0)
        {
            // Adjust overlap to 55% to modify bar spacing
            series[0].ParentSeriesGroup.Overlap = 55;
        }

        // Save the modified presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
        presentation.Dispose();
    }
}