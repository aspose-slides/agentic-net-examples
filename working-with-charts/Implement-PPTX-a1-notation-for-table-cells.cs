using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add a pie chart to the first slide
            Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie, 100, 100, 400, 300);

            // Access the embedded workbook for the chart
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Populate cells using A1-style notation
            // B2 = 10
            workbook.GetCell(0, "B2", 10);
            // B3 = 20
            workbook.GetCell(0, "B3", 20);
            // B4 = formula that sums B2 and B3
            Aspose.Slides.Charts.IChartDataCell formulaCell = workbook.GetCell(0, "B4");
            formulaCell.Formula = "B2+B3";

            // Calculate all formulas in the workbook
            workbook.CalculateFormulas();

            // Output a simple confirmation
            Console.WriteLine("Formula in cell B4 evaluated successfully.");

            // Save the presentation
            pres.Save("A1NotationChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}