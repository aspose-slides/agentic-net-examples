using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Define output file path
        string outputFileName = "ChartWithFormula.pptx";
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), outputFileName);

        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Set sample data values
            workbook.GetCell(0, "B2", 2);
            workbook.GetCell(0, "B3", 3);

            // Assign a formula to cell B4 that sums B2 and B3
            workbook.GetCell(0, "B4").Formula = "B2+B3";

            // Calculate formulas to update the cell values
            workbook.CalculateFormulas();

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}