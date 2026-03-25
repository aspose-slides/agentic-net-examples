using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string workbookPath = "workbook.xlsx";
        string outputPath = "output.pptx";

        if (!File.Exists(workbookPath))
        {
            Console.WriteLine("Workbook file not found: " + workbookPath);
            return;
        }

        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 600, true);
            Aspose.Slides.Charts.IChartData chartData = chart.ChartData;
            ((Aspose.Slides.Charts.ChartData)chartData).SetExternalWorkbook(workbookPath, true);
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}