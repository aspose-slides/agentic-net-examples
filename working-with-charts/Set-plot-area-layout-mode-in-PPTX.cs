using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        var inputPath = args.Length > 0 ? args[0] : "input.pptx";
        var outputPath = args.Length > 1 ? args[1] : "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Error: Input file \"{inputPath}\" not found.");
            return;
        }

        // Load presentation
        var presentation = new Aspose.Slides.Presentation(inputPath);

        // Access first slide
        var slide = presentation.Slides[0];

        // Add a clustered column chart
        var chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 450f, 300f);

        // Set layout mode for the plot area
        chart.PlotArea.AsILayoutable.X = 0.1f;
        chart.PlotArea.AsILayoutable.Y = 0.1f;
        chart.PlotArea.AsILayoutable.Width = 0.8f;
        chart.PlotArea.AsILayoutable.Height = 0.8f;
        chart.PlotArea.LayoutTargetType = Aspose.Slides.Charts.LayoutTargetType.Inner;

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}