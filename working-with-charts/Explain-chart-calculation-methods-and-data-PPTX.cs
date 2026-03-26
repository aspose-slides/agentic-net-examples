using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a pie chart with sample data
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 100f, 100f, 400f, 300f);

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Populate cells B2 and B3 with numeric values
        workbook.GetCell(0, "B2", 2);
        workbook.GetCell(0, "B3", 3);

        // Set a formula in cell B4 to sum B2 and B3
        Aspose.Slides.Charts.IChartDataCell cellB4 = workbook.GetCell(0, "B4");
        cellB4.Formula = "B2+B3";

        // Calculate all formulas in the workbook
        workbook.CalculateFormulas();

        // Show the calculated result in the chart title
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("Sum of B2 and B3 = " + cellB4.Value.ToString());

        // Define output file path
        string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "ChartCalculationDemo.pptx");

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}