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
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Get the chart's data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Set initial values in cells B2 and B3
            workbook.GetCell(0, "B2", 2);
            workbook.GetCell(0, "B3", 3);

            // Assign a formula to cell B4 that sums B2 and B3
            workbook.GetCell(0, "B4").Formula = "B2+B3";

            // Calculate all formulas in the workbook
            workbook.CalculateFormulas();

            // Define output path
            string outPath = Path.Combine(Directory.GetCurrentDirectory(), "ChartWithFormulas.pptx");

            // Save the presentation
            presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}