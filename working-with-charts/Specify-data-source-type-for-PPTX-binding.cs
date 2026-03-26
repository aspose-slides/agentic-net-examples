using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string externalWorkbookPath = "data.xlsx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        Aspose.Slides.ISlide slide = pres.Slides[0];
        Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;

        if (chart != null)
        {
            ((Aspose.Slides.Charts.ChartData)chart.ChartData).SetExternalWorkbook(externalWorkbookPath, false);

            Aspose.Slides.Charts.ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
            if (sourceType == Aspose.Slides.Charts.ChartDataSourceType.ExternalWorkbook)
            {
                string externalPath = chart.ChartData.ExternalWorkbookPath;
                Console.WriteLine("Chart uses external workbook: " + externalPath);
            }
            else
            {
                Console.WriteLine("Chart uses internal workbook.");
            }
        }

        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}