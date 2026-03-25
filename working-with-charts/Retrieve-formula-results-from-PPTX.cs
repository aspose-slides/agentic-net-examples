using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace CalculateFormulasExample
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

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 400, 300);

                // Access the chart's embedded workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Populate cells with values
                workbook.GetCell(0, "B2", 2);
                workbook.GetCell(0, "B3", 3);

                // Set a formula in cell B4 that adds B2 and B3
                workbook.GetCell(0, "B4").Formula = "B2+B3";

                // Calculate all formulas in the workbook
                workbook.CalculateFormulas();

                // Retrieve the calculated result from cell B4
                object calculatedValue = workbook.GetCell(0, "B4").Value;
                Console.WriteLine("Calculated value in B4: " + calculatedValue);

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}