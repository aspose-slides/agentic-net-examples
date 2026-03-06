using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);

        // Access the chart's workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Set cell values
        workbook.GetCell(0, "B2", 2);
        workbook.GetCell(0, "B3", 3);

        // Set formula in B4
        workbook.GetCell(0, "B4").Formula = "B2+B3";

        // Calculate formulas
        workbook.CalculateFormulas();

        // Save the presentation
        string outPath = Path.Combine(Directory.GetCurrentDirectory(), "WorksheetFormulas.pptx");
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}