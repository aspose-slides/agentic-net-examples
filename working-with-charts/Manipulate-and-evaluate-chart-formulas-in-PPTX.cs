using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartFormulaExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string dataDir = Directory.GetCurrentDirectory();
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Assume the first shape on the slide is a chart
            IChart chart = (IChart)slide.Shapes[0];

            // Get the workbook associated with the chart
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Populate some cells with numeric values
            workbook.GetCell(0, "B2", 2);
            workbook.GetCell(0, "B3", 3);

            // Set a formula in cell B4 that adds B2 and B3
            IChartDataCell cellB4 = workbook.GetCell(0, "B4");
            cellB4.Formula = "B2+B3";

            // Calculate all formulas in the workbook
            workbook.CalculateFormulas();

            // Output the calculated value of B4
            Console.WriteLine("Calculated value of B4: " + cellB4.Value);

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}