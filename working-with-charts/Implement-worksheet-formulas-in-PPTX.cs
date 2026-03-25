using System;
using Aspose.Slides.Export;

namespace ChartFormulaExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                // Get the chart data workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Set values in cells B2 and B3
                workbook.GetCell(0, "B2", 2);
                workbook.GetCell(0, "B3", 3);

                // Set a formula in cell B4 to sum B2 and B3
                workbook.GetCell(0, "B4").Formula = "B2+B3";

                // Calculate all formulas in the workbook
                workbook.CalculateFormulas();

                // Save the presentation
                string outPath = System.IO.Path.Combine(
                    System.IO.Directory.GetCurrentDirectory(), "ChartFormulaOutput.pptx");
                presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine("Input file not found: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}