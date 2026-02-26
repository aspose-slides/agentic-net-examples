using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Path to the Excel workbook containing the chart
        string workbookPath = "chartData.xlsx";
        // Worksheet name that contains the chart
        string worksheetName = "Sheet1";
        // Name of the chart in the worksheet
        string chartName = "Chart 1";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add chart from workbook to the first slide at position (10,10)
        Aspose.Slides.Charts.IChart chart = Aspose.Slides.Import.ExcelWorkbookImporter.AddChartFromWorkbook(
            presentation.Slides[0].Shapes,
            10f,
            10f,
            workbookPath,
            worksheetName,
            chartName,
            false);

        // Set chart title
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("Imported Chart");

        // Save the presentation
        presentation.Save("ChartFromWorkbook.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}