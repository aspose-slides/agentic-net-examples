using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a pie chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie, 100, 100, 300, 400);

        // Access the chart's workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Populate cells with values
        workbook.GetCell(0, "B2", 2);
        workbook.GetCell(0, "B3", 3);

        // Set a formula in cell B4
        workbook.GetCell(0, "B4").Formula = "B2+B3";

        // Calculate all formulas
        workbook.CalculateFormulas();

        // Retrieve the calculated result from B4
        object calculationResult = workbook.GetCell(0, "B4").Value;

        // Output the result
        System.Console.WriteLine("Calculated result in B4: " + calculationResult);

        // Save the presentation before exiting
        presentation.Save("CalculationResult.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}