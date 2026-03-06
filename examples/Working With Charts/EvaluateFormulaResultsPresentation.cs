using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 400f, 300f);

        // Access the chart's workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Set values in cells B2 and B3 (row, column are zero‑based)
        workbook.GetCell(0, 1, 1).Value = 2;
        workbook.GetCell(0, 2, 1).Value = 3;

        // Set formula in cell B4 to sum B2 and B3
        workbook.GetCell(0, 3, 1).Formula = "B2+B3";

        // Calculate all formulas in the workbook
        workbook.CalculateFormulas();

        // Save the presentation
        string outPath = Path.Combine(Directory.GetCurrentDirectory(), "EvaluateFormulaResultsPresentation_out.pptx");
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}