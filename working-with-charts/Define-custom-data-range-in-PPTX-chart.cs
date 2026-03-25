using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace CustomChartDataRange
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
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Define the custom data range formula
            string range = "Sheet1!$A$1:$C$4";

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Assume the first shape on the slide is a chart
            IChart chart = slide.Shapes[0] as IChart;

            // Set the custom data range for the chart
            chart.ChartData.SetRange(range);

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();

            Console.WriteLine("Chart data range updated and presentation saved to " + outputPath);
        }
    }
}