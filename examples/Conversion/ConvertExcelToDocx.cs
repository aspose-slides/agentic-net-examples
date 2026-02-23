using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;
using Aspose.Slides.Charts;
using Aspose.Slides.Excel;

namespace ConvertExcelToPresentation
{
    class Program
    {
        static void Main()
        {
            // Define input Excel file and output presentation file paths
            string dataDir = @"C:\Data";
            string excelPath = Path.Combine(dataDir, "input.xlsx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get a blank layout slide to add content
            Aspose.Slides.ILayoutSlide blankLayout = pres.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
            Aspose.Slides.ISlide slide = pres.Slides.AddEmptySlide(blankLayout);

            // Load the Excel workbook
            Aspose.Slides.Excel.ExcelDataWorkbook workbook = new Aspose.Slides.Excel.ExcelDataWorkbook(excelPath);

            // Add a chart from the workbook to the slide
            Aspose.Slides.Charts.IChart chart = Aspose.Slides.Import.ExcelWorkbookImporter.AddChartFromWorkbook(
                slide.Shapes,
                10f,
                10f,
                workbook,
                "Sheet1",
                "Chart 1",
                false);

            // Optionally set chart data range (example range)
            chart.ChartData.SetRange("A1:C5");

            // Save the presentation (must save before exiting)
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}