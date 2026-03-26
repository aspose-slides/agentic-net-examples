using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            var slide = presentation.Slides[0];

            // Assume the first shape is a chart
            var chart = (Aspose.Slides.Charts.IChart)slide.Shapes[0];

            // Access the chart's embedded workbook
            var workbook = chart.ChartData.ChartDataWorkbook;

            // Set values and a formula in the workbook
            workbook.GetCell(0, "B2", 2);
            workbook.GetCell(0, "B3", 3);
            workbook.GetCell(0, "B4").Formula = "B2+B3";

            // Calculate all formulas
            workbook.CalculateFormulas();

            // Save the updated presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}