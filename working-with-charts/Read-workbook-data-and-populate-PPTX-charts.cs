using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

namespace ChartFromWorkbookExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string workbookPath = "data.xlsx";
            string outputPath = "output.pptx";

            // Verify that the workbook exists
            if (!File.Exists(workbookPath))
            {
                Console.WriteLine("Workbook file not found: " + workbookPath);
                return;
            }

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a chart from the workbook to the first slide
            // Parameters: shape collection, X, Y, workbook path, worksheet name, chart name, embedWorkbook flag
            Aspose.Slides.Charts.IChart chart = Aspose.Slides.Import.ExcelWorkbookImporter.AddChartFromWorkbook(
                presentation.Slides[0].Shapes,
                50f,
                50f,
                workbookPath,
                "Sheet1",
                "Chart 1",
                false);

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}