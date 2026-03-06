using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Add a pie chart to the first slide
        var chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie, 100, 100, 400, 300);

        // Access the embedded workbook of the chart
        var workbook = chart.ChartData.ChartDataWorkbook;

        // Populate cells B2 and B3 with numeric values
        workbook.GetCell(0, "B2", 2);
        workbook.GetCell(0, "B3", 3);

        // Set a formula in cell B4 that adds B2 and B3
        var cellB4 = workbook.GetCell(0, "B4");
        cellB4.Formula = "B2+B3";

        // Calculate all formulas in the workbook
        workbook.CalculateFormulas();

        // Save the presentation to disk
        presentation.Save("ChartWithFormulas_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}