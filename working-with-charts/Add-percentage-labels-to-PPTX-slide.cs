using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        // Load the existing presentation
        var presentation = new Aspose.Slides.Presentation(inputPath);

        // Get the first slide
        var slide = presentation.Slides[0];

        // Add a stacked column chart to the slide
        var chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.StackedColumn,
            50,   // X position
            50,   // Y position
            500,  // Width
            400   // Height
        );

        // Enable value and percentage display for data labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = true;

        // Set a numeric format for the percentages
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}