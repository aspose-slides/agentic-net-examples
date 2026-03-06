using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace OptimizedChartCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide (index 0)
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart with sample data
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f,   // X position
                50f,   // Y position
                500f,  // Width
                400f   // Height
            );

            // Get the workbook that holds chart data
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Set numeric values in cells B2 and B3 (row 1, column 1 and row 2, column 1)
            workbook.GetCell(0, 1, 2).Value = 2; // Cell B2 = 2
            workbook.GetCell(0, 2, 3).Value = 3; // Cell B3 = 3

            // Set a formula in cell B4 (row 3, column 1) to sum B2 and B3
            Aspose.Slides.Charts.IChartDataCell formulaCell = workbook.GetCell(0, 3, 0);
            formulaCell.Formula = "B2+B3";

            // Calculate all formulas in the workbook
            workbook.CalculateFormulas();

            // Save the presentation to disk
            presentation.Save("OptimizedChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}