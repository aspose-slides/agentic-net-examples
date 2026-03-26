using System;
using System.IO;
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
            Console.WriteLine("The input file does not exist.");
            return;
        }

        // Load the existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a chart to the slide (if needed)
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0f, 0f, 500f, 400f);

        // Set the legend font size (in points)
        chart.Legend.TextFormat.PortionFormat.FontHeight = 14f;

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}