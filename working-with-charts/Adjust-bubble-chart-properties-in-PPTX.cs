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

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Access the first slide and assume the first shape is a bubble chart
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;
        if (chart == null)
        {
            Console.WriteLine("No chart found on the first slide.");
            return;
        }

        // Set bubble size representation to Width
        chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

        // Set bubble size scaling to 150%
        chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

        // Show bubble size values in data labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowBubbleSize = true;

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}