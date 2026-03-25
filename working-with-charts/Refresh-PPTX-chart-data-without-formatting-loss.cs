using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace UpdateChartData
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string workbookPath = "data.xlsx";

            // Verify that the input presentation exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Verify that the external workbook exists
            if (!File.Exists(workbookPath))
            {
                Console.WriteLine("Error: Workbook file not found - " + workbookPath);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Find the first chart on the slide
            IChart chart = null;
            for (int i = 0; i < slide.Shapes.Count; i++)
            {
                chart = slide.Shapes[i] as IChart;
                if (chart != null)
                {
                    break;
                }
            }

            if (chart == null)
            {
                Console.WriteLine("Error: No chart found in the presentation.");
                presentation.Dispose();
                return;
            }

            // Update chart data from the external workbook while preserving formatting
            ChartData chartData = chart.ChartData as ChartData;
            if (chartData != null)
            {
                chartData.SetExternalWorkbook(workbookPath, true);
            }

            // Save the updated presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();

            Console.WriteLine("Chart data updated and presentation saved to " + outputPath);
        }
    }
}