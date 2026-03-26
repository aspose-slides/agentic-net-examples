using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a chart without initializing sample data for faster creation
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f, false);

        // Access the chart's data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Populate some cells and set a formula
        workbook.GetCell(0, "B2", 2);
        workbook.GetCell(0, "B3", 3);
        Aspose.Slides.Charts.IChartDataCell formulaCell = workbook.GetCell(0, "B4");
        formulaCell.Formula = "B2+B3";

        // Calculate formulas to optimize rendering performance
        workbook.CalculateFormulas();

        // Save the presentation
        string outputPath = "ChartOptimization_out.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}