using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartFormulaExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "ChartWithFormulas.pptx");

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100f, 100f, 400f, 300f);

            // Access the chart's data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Populate cells with values
            workbook.GetCell(0, "B2", 2);
            workbook.GetCell(0, "B3", 3);

            // Set a formula in cell B4
            IChartDataCell cellB4 = workbook.GetCell(0, "B4");
            cellB4.Formula = "B2+B3";

            // Calculate all formulas in the workbook
            workbook.CalculateFormulas();

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}