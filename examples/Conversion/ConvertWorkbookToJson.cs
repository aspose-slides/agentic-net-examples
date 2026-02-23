using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Excel;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output paths
        string dataDir = @"C:\Data";
        string excelPath = Path.Combine(dataDir, "input.xlsx");
        string jsonOutputPath = Path.Combine(dataDir, "output.json");
        string presentationPath = Path.Combine(dataDir, "temp.pptx");

        // Load the Excel workbook
        Aspose.Slides.Excel.IExcelDataWorkbook workbook = new Aspose.Slides.Excel.ExcelDataWorkbook(excelPath);

        // Retrieve worksheet names
        IEnumerable<string> worksheetNames = workbook.GetWorksheetNames();

        // Prepare a dictionary to hold workbook data for JSON serialization
        Dictionary<string, object> workbookData = new Dictionary<string, object>();

        foreach (string wsName in worksheetNames)
        {
            // For demonstration, store an empty list for each worksheet
            workbookData[wsName] = new List<Dictionary<string, object>>();
        }

        // Serialize the dictionary to a formatted JSON string
        string jsonString = JsonSerializer.Serialize(workbookData, new JsonSerializerOptions { WriteIndented = true });

        // Write JSON to the output file
        File.WriteAllText(jsonOutputPath, jsonString);

        // Create an empty presentation and save it (required by authoring rules)
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
        pres.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}