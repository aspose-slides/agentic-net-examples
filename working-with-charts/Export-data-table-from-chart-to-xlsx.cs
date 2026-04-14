using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        string presentationPath = "input.pptx";
        string outputExcelPath = "chartData.xlsx";

        if (!File.Exists(presentationPath))
        {
            Console.WriteLine("Presentation file not found.");
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(presentationPath))
            {
                IChart chart = null;
                foreach (IShape shape in pres.Slides[0].Shapes)
                {
                    chart = shape as IChart;
                    if (chart != null)
                        break;
                }

                if (chart == null)
                {
                    Console.WriteLine("No chart found in the presentation.");
                }
                else
                {
                    if (!chart.HasDataTable)
                    {
                        chart.HasDataTable = true;
                    }

                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                    MemoryStream workbookStream = ((ChartData)chart.ChartData).ReadWorkbookStream();

                    using (FileStream fileStream = new FileStream(outputExcelPath, FileMode.Create, FileAccess.Write))
                    {
                        workbookStream.WriteTo(fileStream);
                    }

                    Console.WriteLine("Chart data exported to " + outputExcelPath);
                }

                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}