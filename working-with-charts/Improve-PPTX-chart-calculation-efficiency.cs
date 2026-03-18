using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "OptimizedChart.pptx");
            using (Presentation presentation = new Presentation())
            {
                // Add chart without initializing sample data for faster creation
                IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 600f, 400f, false);

                // Access the embedded workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Populate some sample data
                workbook.GetCell(0, "A1", "Category 1");
                workbook.GetCell(0, "B1", 10);
                workbook.GetCell(0, "A2", "Category 2");
                workbook.GetCell(0, "B2", 20);

                // Calculate any formulas present in the workbook
                workbook.CalculateFormulas();

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}