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

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50,   // X position
            50,   // Y position
            400,  // Width
            300   // Height
        );

        // Access the embedded workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Set values for B2 and B3 cells
        workbook.GetCell(0, "B2", 2);
        workbook.GetCell(0, "B3", 3);

        // Set a formula for B4 cell (B2+B3)
        workbook.GetCell(0, "B4").Formula = "B2+B3";

        // Calculate all formulas in the workbook
        workbook.CalculateFormulas();

        // Save the presentation
        string outPath = System.IO.Path.Combine(
            System.IO.Directory.GetCurrentDirectory(),
            "WorksheetFormulas.pptx"
        );
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}