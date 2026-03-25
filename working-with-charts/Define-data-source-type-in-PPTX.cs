using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string externalWorkbookPath = "data.xlsx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            Presentation pres = new Presentation(inputPath);
            ISlide slide = pres.Slides[0];
            IChart chart = slide.Shapes[0] as IChart;
            if (chart != null)
            {
                // Set external workbook as data source
                ((ChartData)chart.ChartData).SetExternalWorkbook(externalWorkbookPath);

                // Check data source type
                ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
                if (sourceType == ChartDataSourceType.ExternalWorkbook)
                {
                    string path = chart.ChartData.ExternalWorkbookPath;
                    Console.WriteLine("External workbook set: " + path);
                }
            }

            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}