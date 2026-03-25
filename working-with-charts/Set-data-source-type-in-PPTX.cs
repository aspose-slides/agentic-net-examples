using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string workbookPath = "data.xlsx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input presentation file not found: " + inputPath);
            return;
        }

        if (!File.Exists(workbookPath))
        {
            Console.WriteLine("External workbook file not found: " + workbookPath);
            return;
        }

        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
        Aspose.Slides.ISlide slide = pres.Slides[0];
        Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;

        if (chart != null)
        {
            ((Aspose.Slides.Charts.ChartData)chart.ChartData).SetExternalWorkbook(workbookPath);
            Aspose.Slides.Charts.ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
            Console.WriteLine("Data source type: " + sourceType);
            if (sourceType == Aspose.Slides.Charts.ChartDataSourceType.ExternalWorkbook)
            {
                string externalPath = chart.ChartData.ExternalWorkbookPath;
                Console.WriteLine("External workbook path: " + externalPath);
            }
        }

        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}