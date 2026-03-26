using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace RenameChartSeries
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Find the first chart on the slide
                IChart chart = null;
                for (int i = 0; i < slide.Shapes.Count; i++)
                {
                    if (slide.Shapes[i] is IChart)
                    {
                        chart = (IChart)slide.Shapes[i];
                        break;
                    }
                }

                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                    return;
                }

                // Rename the first series
                // Create a new cell with the desired series name
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;
                IChartDataCell newNameCell = workbook.GetCell(defaultWorksheetIndex, 0, 1, "New Series Name");

                // Add a new series using the new name cell
                IChartSeries newSeries = chart.ChartData.Series.Add(newNameCell, chart.Type);

                // Optionally copy data points from the old series to the new series
                // (Here we simply remove the old series without copying data)
                chart.ChartData.Series.RemoveAt(0);

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
        }
    }
}