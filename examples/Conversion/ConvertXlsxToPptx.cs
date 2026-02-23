using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Import;
using Aspose.Slides.Excel;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input Excel file and output PPTX file
        string dataDir = @"C:\Data";
        string excelPath = Path.Combine(dataDir, "input.xlsx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get a blank layout slide to use for new slides
        Aspose.Slides.ILayoutSlide blankLayout = pres.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);

        // Load the Excel workbook
        Aspose.Slides.Excel.ExcelDataWorkbook workbook = new Aspose.Slides.Excel.ExcelDataWorkbook(excelPath);

        // Iterate through each worksheet in the workbook
        IEnumerable<string> worksheetNames = workbook.GetWorksheetNames();
        foreach (string wsName in worksheetNames)
        {
            // Get all charts from the current worksheet
            IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(wsName);
            foreach (KeyValuePair<int, string> chartInfo in worksheetCharts)
            {
                // Add a new empty slide based on the blank layout
                Aspose.Slides.ISlide slide = pres.Slides.AddEmptySlide(blankLayout);

                // Import the chart from the workbook onto the slide
                Aspose.Slides.Import.ExcelWorkbookImporter.AddChartFromWorkbook(
                    slide.Shapes,
                    10f,
                    10f,
                    workbook,
                    wsName,
                    chartInfo.Key,
                    false);
            }
        }

        // Save the presentation as PPTX
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}