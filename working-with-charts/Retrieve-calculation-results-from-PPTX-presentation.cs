using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace RetrieveChartCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path (can be passed as first argument)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    ISlide slide = pres.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Cast shape to IChart if possible
                        IChart chart = shape as IChart;
                        if (chart != null)
                        {
                            // Calculate all formulas in the chart's workbook
                            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                            workbook.CalculateFormulas();

                            // Retrieve the data range of the chart
                            string range = (chart.ChartData as ChartData).GetRange();

                            Console.WriteLine($"Slide {slideIndex + 1}, Chart {shapeIndex + 1}: Data Range = {range}");

                            // Example: read a specific cell value (e.g., B2) from the first worksheet
                            int defaultWorksheetIndex = 0;
                            IChartDataCell cell = workbook.GetCell(defaultWorksheetIndex, "B2");
                            Console.WriteLine($"Cell B2 Value = {cell.Value}");
                        }
                    }
                }

                // Save the presentation (even if unchanged) to a new file
                string outputPath = "output.pptx";
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
        }
    }
}