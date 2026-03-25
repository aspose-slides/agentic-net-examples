using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace RetrieveChartFormulas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Access first slide (adjust index as needed)
                ISlide slide = presentation.Slides[0];

                // Find the first chart on the slide
                IChart chart = null;
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is IChart)
                    {
                        chart = (IChart)shape;
                        break;
                    }
                }

                if (chart != null)
                {
                    // Access the chart's workbook
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                    // Calculate all formulas in the workbook
                    workbook.CalculateFormulas();

                    // Example: retrieve the calculated value from cell B4 (first worksheet)
                    IChartDataCell resultCell = workbook.GetCell(0, "B4");
                    object calculatedValue = resultCell.Value;

                    Console.WriteLine("Calculated value in B4: " + calculatedValue);
                }
                else
                {
                    Console.WriteLine("No chart found on the first slide.");
                }

                // Save the presentation after processing
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}