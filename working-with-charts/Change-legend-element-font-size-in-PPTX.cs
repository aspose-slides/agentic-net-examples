using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
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

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a chart to the slide (or retrieve an existing one)
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 400f, 300f);

        // Adjust the legend font size
        chart.Legend.TextFormat.PortionFormat.FontHeight = 14f;

        // Save the modified presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
        presentation.Dispose();
    }
}