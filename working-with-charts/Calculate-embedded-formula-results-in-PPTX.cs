using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input and output presentations
        string inputPath = "InputPresentation.pptx";
        string outputPath = "OutputPresentation.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load the presentation
        using (Presentation presentation = new Presentation(inputPath))
        {
            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Find the first chart on the slide
            IChart chart = null;
            foreach (IShape shape in slide.Shapes)
            {
                chart = shape as IChart;
                if (chart != null)
                {
                    break;
                }
            }

            if (chart == null)
            {
                Console.WriteLine("No chart found in the presentation.");
                return;
            }

            // Access the chart's data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Calculate all formulas in the workbook
            workbook.CalculateFormulas();

            // Retrieve the calculated value from a specific cell (e.g., B4)
            IChartDataCell resultCell = workbook.GetCell(0, "B4");
            Console.WriteLine("Calculated value of B4: " + resultCell.Value);

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}