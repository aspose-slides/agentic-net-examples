using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths and the desired data range
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string range = "Sheet1!$A$1:$C$4";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        // Get the first shape as a chart
        Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)slide.Shapes[0];
        // Set the new data range for the chart
        chart.ChartData.SetRange(range);
        // Save the updated presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        // Dispose the presentation object
        presentation.Dispose();
    }
}