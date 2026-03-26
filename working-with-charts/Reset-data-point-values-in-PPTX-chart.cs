using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        System.String inputPath = "input.pptx";
        System.String outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Access the first slide and the first shape (assumed to be a chart)
        Aspose.Slides.ISlide slide = pres.Slides[0];
        Aspose.Slides.IShape shape = slide.Shapes[0];
        Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;

        // If a chart is found and it contains at least one series
        if (chart != null && chart.ChartData.Series.Count > 0)
        {
            // Get the first series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Remove the first data point of the series if it exists
            if (series.DataPoints.Count > 0)
            {
                series.DataPoints[0].Remove();
            }

            // Example: clear all data points of the second series (if present)
            if (chart.ChartData.Series.Count > 1)
            {
                chart.ChartData.Series[1].DataPoints.Clear();
            }
        }

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}