using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;
using Aspose.Slides.Excel;

namespace WorksheetManagementDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string excelPath = "data.xlsx";

            // Verify that input files exist
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file not found: " + inputPath);
                return;
            }

            if (!File.Exists(excelPath))
            {
                Console.WriteLine("Excel workbook file not found: " + excelPath);
                return;
            }

            // Load presentation with option to delete embedded binary objects
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DeleteEmbeddedBinaryObjects = true;
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath, loadOptions))
            {
                // Load Excel workbook
                Aspose.Slides.Excel.IExcelDataWorkbook workbook = new Aspose.Slides.Excel.ExcelDataWorkbook(excelPath);

                // Add a chart from the workbook to the first slide
                Aspose.Slides.Charts.IChart chart = Aspose.Slides.Import.ExcelWorkbookImporter.AddChartFromWorkbook(
                    pres.Slides[0].Shapes,
                    10f,
                    10f,
                    workbook,
                    "Sheet1",
                    0,
                    false);

                // Modify a cell in the embedded chart workbook (e.g., set A1 to "Modified")
                Aspose.Slides.Charts.IChartDataWorkbook chartWorkbook = chart.ChartData.ChartDataWorkbook;
                chartWorkbook.GetCell(0, "A1", "Modified");

                // Remove the added chart shape (demonstrating removal of embedded sheet)
                pres.Slides[0].Shapes.Remove(chart);

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            Console.WriteLine("Worksheet management operations completed. Output saved to: " + outputPath);
        }
    }
}