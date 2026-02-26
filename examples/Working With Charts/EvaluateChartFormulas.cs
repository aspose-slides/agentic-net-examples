using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a pie chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie, 100, 100, 300, 400);

        // Access the chart's embedded workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Populate cells B2 and B3 with numeric values
        workbook.GetCell(0, "B2", 2);
        workbook.GetCell(0, "B3", 3);

        // Set a formula in cell B4 that sums B2 and B3
        Aspose.Slides.Charts.IChartDataCell formulaCell = workbook.GetCell(0, "B4");
        formulaCell.Formula = "B2+B3";

        // Calculate all formulas in the workbook
        workbook.CalculateFormulas();

        // Retrieve the calculated result from B4
        object calculatedValue = formulaCell.Value;

        // Output the result to the console
        Console.WriteLine("Calculated value in B4: " + calculatedValue);

        // Save the presentation
        presentation.Save("ChartFormulaResult.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}