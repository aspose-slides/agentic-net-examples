using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using Aspose.Slides.Excel;
using Aspose.Slides.Import;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for the output presentation and the source Excel workbook
            string presentationPath = "output.pptx";
            string workbookPath = "data.xlsx";
            string worksheetName = "Sheet1";

            // Load the Excel workbook that contains chart data
            IExcelDataWorkbook workbook = new ExcelDataWorkbook(workbookPath);

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Add a chart from the workbook to the first slide
                // Parameters: shape collection, X, Y, workbook, worksheet name, chart index, embedAllWorkbook
                IChart chart = ExcelWorkbookImporter.AddChartFromWorkbook(
                    presentation.Slides[0].Shapes,
                    50f,
                    50f,
                    workbook,
                    worksheetName,
                    0,
                    false);

                // Additional chart manipulation can be done here if needed

                // Save the presentation before exiting
                presentation.Save(presentationPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Simple error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}