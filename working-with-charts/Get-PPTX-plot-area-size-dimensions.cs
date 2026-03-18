using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Get the first slide
            var slide = presentation.Slides[0];

            // Assume the first shape on the slide is a chart
            var chart = (Aspose.Slides.Charts.IChart)slide.Shapes[0];

            // Calculate actual layout values
            chart.ValidateChartLayout();

            // Retrieve plot area dimensions
            var plotArea = chart.PlotArea;
            var actualWidth = plotArea.ActualWidth;
            var actualHeight = plotArea.ActualHeight;

            Console.WriteLine($"Plot Area Actual Width: {actualWidth}");
            Console.WriteLine($"Plot Area Actual Height: {actualHeight}");

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}