using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartPerformanceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            try
            {
                // Load the existing presentation
                Presentation presentation = new Presentation(inputPath);

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart without sample data for better performance
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0f, 0f, 500f, 400f, false);

                // Access the chart's data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Populate some cells with values and a formula
                workbook.GetCell(0, "B2", 2);
                workbook.GetCell(0, "B3", 3);
                workbook.GetCell(0, "B4").Formula = "B2+B3";

                // Calculate all formulas in the workbook
                workbook.CalculateFormulas();

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);

                // Release resources
                presentation.Dispose();

                Console.WriteLine("Presentation processed and saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}