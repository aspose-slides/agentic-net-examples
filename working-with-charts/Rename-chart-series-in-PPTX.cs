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
        string dataDir = Directory.GetCurrentDirectory();
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        using (Presentation pres = new Presentation(inputPath))
        {
            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Assume the first shape on the slide is a chart
            IChart chart = (IChart)slide.Shapes[0];

            // Access the first series of the chart
            IChartSeries series = chart.ChartData.Series[0];

            // Rename the series using the literal string property
            series.Name.AsLiteralString = "Renamed Series";

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}