using System;
using System.IO;
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
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50, 150, 400, 300);

        // Access the chart's data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Set values in cells B2 and B3
        workbook.GetCell(0, "B2", 2);
        workbook.GetCell(0, "B3", 3);

        // Set a formula in cell B4 that adds B2 and B3
        workbook.GetCell(0, "B4").Formula = "B2+B3";

        // Calculate all formulas in the workbook
        workbook.CalculateFormulas();

        // Add an overview slide describing worksheet formulas
        Aspose.Slides.ISlide overviewSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

        // Add a textbox with the overview text
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)overviewSlide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle,
            50, 50, 600, 400);
        autoShape.AddTextFrame(
            "Worksheet Formulas Overview\r\n" +
            "- Use ChartDataWorkbook to set formulas\r\n" +
            "- Call CalculateFormulas() to evaluate\r\n" +
            "- Cell B4 = B2 + B3");

        // Save the presentation
        string outPath = Path.Combine(Directory.GetCurrentDirectory(), "WorksheetFormulasDemo.pptx");
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}