using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace DoughnutHoleSizeExample
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
            using (Presentation pres = new Presentation(inputPath))
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a doughnut chart to the slide
                IChart chart = slide.Shapes.AddChart(
                    ChartType.Doughnut,
                    50f,   // X position
                    50f,   // Y position
                    400f,  // Width
                    400f   // Height
                );

                // Ensure there is at least one series to access the ParentSeriesGroup
                if (chart.ChartData.Series.Count == 0)
                {
                    // Add a default series if none exist
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
                }

                // Set the doughnut hole size (percentage of plot area, 0-90)
                chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = (byte)50;

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }

            Console.WriteLine("Presentation saved to " + outputPath);
        }
    }
}