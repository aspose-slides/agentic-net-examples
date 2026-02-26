using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Import;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths to the source presentation and the Excel workbook
        string presentationPath = "input.pptx";
        string workbookPath = "data.xlsx";

        // Load the existing presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath))
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a chart from the Excel workbook to the slide
            Aspose.Slides.Charts.IChart chart = Aspose.Slides.Import.ExcelWorkbookImporter.AddChartFromWorkbook(
                slide.Shapes,
                50f,                     // X position
                50f,                     // Y position
                workbookPath,            // Path to the workbook
                "Sheet1",                // Worksheet name
                "Chart 1",               // Chart name in the worksheet
                false);                  // Do not embed the whole workbook

            // Access the embedded workbook of the chart
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Modify cell values and set a formula
            workbook.GetCell(0, "B2", 10);
            workbook.GetCell(0, "B3", 20);
            workbook.GetCell(0, "B4").Formula = "B2+B3";

            // Recalculate formulas to update dependent cells
            workbook.CalculateFormulas();

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}