// -----------------------------------------------------------------------------
// Example: Export data table from chart to xlsx using C#
//
// Description:
// Demonstrates how to export a chart's data table to an Excel workbook (xlsx)
// using Aspose.Slides for .NET. The example loads a PPTX file, ensures the
// chart contains a data table, extracts the underlying workbook stream, writes
// it to an .xlsx file, and saves the modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Data Table, Chart, Excel,
// XLSX, Presentation Processing, Office Automation
//
// Use Cases:
// - Export chart data to Excel for further analysis or reporting.
// - Automate extraction of chart data tables from PowerPoint presentations.
// - Build .NET tools that integrate PowerPoint chart data with other systems.
// - Incorporate chart data export functionality into larger .NET applications.
// -----------------------------------------------------------------------------
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
