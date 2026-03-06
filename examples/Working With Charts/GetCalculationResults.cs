using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0, 0, 500, 400);

        // Access the embedded workbook for the chart
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Populate cells B2 and B3 with numeric values
        workbook.GetCell(0, "B2", 2);
        workbook.GetCell(0, "B3", 3);

        // Set a formula in cell B4 that adds B2 and B3
        workbook.GetCell(0, "B4").Formula = "B2+B3";

        // Calculate all formulas in the workbook
        workbook.CalculateFormulas();

        // Retrieve the calculated value from cell B4 (returned as object)
        object cellValue = workbook.GetCell(0, "B4").Value;

        // Convert the object to double explicitly
        double result = Convert.ToDouble(cellValue);

        // Display the calculation result
        Console.WriteLine("Calculated value in B4: " + result);

        // Save the presentation before exiting
        presentation.Save("GetCalculationResults_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}