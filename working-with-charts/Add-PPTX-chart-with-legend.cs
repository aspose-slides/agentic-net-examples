using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartInsertionExample
{
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

            // Load the existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Specify the chart type to insert (can be changed as needed)
            Aspose.Slides.Charts.ChartType chartType = Aspose.Slides.Charts.ChartType.ClusteredColumn;

            // Insert the chart onto the slide at the desired position and size
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(chartType, 50f, 50f, 500f, 400f);

            // (Optional) Additional chart configuration can be added here

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}