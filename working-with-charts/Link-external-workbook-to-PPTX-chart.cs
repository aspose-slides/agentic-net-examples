using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(dataDir);
            string workbookPath = Path.Combine(dataDir, "workbook.xlsx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            if (!File.Exists(workbookPath))
            {
                throw new FileNotFoundException("External workbook not found.", workbookPath);
            }

            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 600, true);
            Aspose.Slides.Charts.IChartData chartData = chart.ChartData;
            ((Aspose.Slides.Charts.ChartData)chartData).SetExternalWorkbook(workbookPath, false);

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}