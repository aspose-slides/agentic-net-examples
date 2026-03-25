using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation from the input file
        Presentation presentation = new Presentation(inputPath);

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 450f, 300f);

        // Reposition the plot area within the chart
        chart.PlotArea.AsILayoutable.X = 0.1f;      // Set X as a fraction of chart width
        chart.PlotArea.AsILayoutable.Y = 0.1f;      // Set Y as a fraction of chart height
        chart.PlotArea.AsILayoutable.Width = 0.8f;  // Set width as a fraction of chart width
        chart.PlotArea.AsILayoutable.Height = 0.8f; // Set height as a fraction of chart height
        chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner; // Layout relative to inner area

        // Save the modified presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}