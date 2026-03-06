using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0f, 0f, 500f, 500f);

        // Get the chart's data workbook to manipulate cells
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Set a formula in cell A1 (sheet 0, row 0, column 0)
        workbook.GetCell(0, 0, 0).Formula = "SUM(B1:C1)";

        // Set values in cells B1 and C1 (sheet 0, row 0, columns 1 and 2)
        workbook.GetCell(0, 0, 1).Value = 10;
        workbook.GetCell(0, 0, 2).Value = 20;

        // Calculate formulas to update the result in A1
        workbook.CalculateFormulas();

        // Save the presentation to a PPTX file
        presentation.Save("ChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}