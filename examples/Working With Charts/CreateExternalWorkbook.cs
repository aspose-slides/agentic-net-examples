using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define the directory and file names
        string dataDir = Directory.GetCurrentDirectory();
        string presentationFileName = "ExternalWorkbookPresentation.pptx";
        string workbookFileName = "ExternalWorkbook.xlsx";

        // Build full paths for the presentation and the external workbook
        string presentationPath = Path.Combine(dataDir, presentationFileName);
        string workbookPath = Path.Combine(dataDir, workbookFileName);

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a pie chart to the first slide
        Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 300);

        // Delete the workbook file if it already exists
        if (File.Exists(workbookPath))
        {
            File.Delete(workbookPath);
        }

        // Extract the internal workbook data to a byte array
        byte[] workbookData = chart.ChartData.ReadWorkbookStream().ToArray();

        // Write the workbook data to an external file
        using (FileStream fs = new FileStream(workbookPath, FileMode.Create, FileAccess.Write))
        {
            fs.Write(workbookData, 0, workbookData.Length);
        }

        // Set the external workbook as the chart's data source
        ((Aspose.Slides.Charts.ChartData)chart.ChartData).SetExternalWorkbook(workbookPath);

        // Save the presentation
        pres.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}