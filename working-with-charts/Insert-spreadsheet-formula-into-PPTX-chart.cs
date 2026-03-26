using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "ChartWithFormula.pptx");

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 600f, 400f);

        // Get the chart's data workbook
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Set values in cells B2 and B3
        workbook.GetCell(0, "B2", 2);
        workbook.GetCell(0, "B3", 3);

        // Set a formula in cell B4 to sum B2 and B3
        workbook.GetCell(0, "B4").Formula = "B2+B3";

        // Calculate all formulas in the workbook
        workbook.CalculateFormulas();

        // Save the presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}