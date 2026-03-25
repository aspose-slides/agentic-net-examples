using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths (can be overridden by command line arguments)
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (args.Length > 0)
        {
            inputPath = args[0];
        }
        if (args.Length > 1)
        {
            outputPath = args[1];
        }

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Ensure there is at least one slide
        if (presentation.Slides.Count == 0)
        {
            // Add an empty slide based on the default layout
            presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        }

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Get the series collection of the chart
        Aspose.Slides.Charts.IChartSeriesCollection seriesCollection = chart.ChartData.Series;

        // Set the series overlap if it is at the default value (0)
        if (seriesCollection[0].Overlap == 0)
        {
            // Adjust overlap to 55% (positive values increase overlap)
            seriesCollection[0].ParentSeriesGroup.Overlap = 55;
        }

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}