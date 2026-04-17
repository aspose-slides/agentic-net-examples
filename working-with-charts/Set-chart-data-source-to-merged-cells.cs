using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

class Program
{
    static void Main()
    {
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        string excelPath = Path.Combine(dataDir, "ChartData.xlsx");
        string outputPath = Path.Combine(dataDir, "ChartWithMergedCells.pptx");

        if (!File.Exists(excelPath))
        {
            Console.WriteLine("Excel file not found: " + excelPath);
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add chart from workbook (embed only chart data)
            Aspose.Slides.Charts.IChart chart = Aspose.Slides.Import.ExcelWorkbookImporter.AddChartFromWorkbook(
                presentation.Slides[0].Shapes,
                50f,
                50f,
                excelPath,
                "Sheet1",
                "Chart1",
                false);

            // Set data range that includes merged cells, e.g., "Sheet1!$A$1:$C$5"
            chart.ChartData.SetRange("Sheet1!$A$1:$C$5");

            // Save presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (ArgumentException ex)
        {
            // Handle unsupported format or missing chart
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (IOException ex)
        {
            // Handle I/O errors
            Console.WriteLine("I/O Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }
}