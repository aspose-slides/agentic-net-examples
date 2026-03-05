using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace EvaluateFormulaResultsPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f,   // X position
                50f,   // Y position
                400f,  // Width
                300f   // Height
            );

            // Access the chart's data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Set a formula in cell B2 (row 1, column 1) that adds B3 and B4
            workbook.GetCell(0, 1, 1).Formula = "B3+B4";

            // Set values for B3 (row 2, column 1) and B4 (row 3, column 1)
            workbook.GetCell(0, 2, 1).Value = 2;
            workbook.GetCell(0, 3, 1).Value = 3;

            // Calculate all formulas in the workbook
            workbook.CalculateFormulas();

            // Save the presentation
            presentation.Save("EvaluateFormulaResultsPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}