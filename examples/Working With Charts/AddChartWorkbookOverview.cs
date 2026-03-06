using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Path to the Excel workbook that contains the chart
        string workbookPath = Path.Combine("Data", "ChartData.xlsx");
        // Worksheet and chart name inside the workbook
        string worksheetName = "Sheet1";
        string chartName = "Chart 1";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the shape collection of the first slide
        Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

        // Import the chart from the Excel workbook and add it to the slide
        Aspose.Slides.Import.ExcelWorkbookImporter.AddChartFromWorkbook(
            shapes,
            50f,               // X position
            50f,               // Y position
            workbookPath,
            worksheetName,
            chartName,
            false);            // Do not embed the entire workbook

        // Save the presentation
        presentation.Save("ChartFromWorkbook_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}