using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Determine output file path (default if not provided)
        string outputPath = "CustomPieChart.pptx";
        if (args.Length > 0)
        {
            outputPath = args[0];
        }

        // Optional input file check (demonstrates exception handling for missing files)
        string inputPath = null;
        if (args.Length > 1)
        {
            inputPath = args[1];
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }
        }

        // Ensure the output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir) && !Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a pie chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

        // Retrieve the first series of the chart
        IChartSeries series = chart.ChartData.Series[0];

        // Explode the second slice (index 1) by 20%
        series.DataPoints[1].Explosion = 20;

        // Save the presentation
        pres.Save(outputPath, SaveFormat.Pptx);
    }
}