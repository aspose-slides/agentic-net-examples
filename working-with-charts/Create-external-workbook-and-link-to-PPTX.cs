using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExternalWorkbookLinkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string workbookPath = "externalData.xlsx";
            string presentationPath = "LinkedChartPresentation.pptx";

            try
            {
                // Ensure the external workbook exists; if not, create a minimal workbook from a temporary chart.
                if (!File.Exists(workbookPath))
                {
                    using (Presentation tempPres = new Presentation())
                    {
                        // Add a temporary chart to generate an internal workbook.
                        IChart tempChart = tempPres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 400, 300);
                        IChartData tempChartData = tempChart.ChartData;

                        // Write the internal workbook to a file.
                        using (MemoryStream ms = new MemoryStream())
                        {
                            ((ChartData)tempChartData).WriteWorkbookStream(ms);
                            ms.Position = 0;
                            using (FileStream fs = new FileStream(workbookPath, FileMode.Create, FileAccess.Write))
                            {
                                ms.CopyTo(fs);
                            }
                        }
                    }
                }

                // Create the target presentation and add a chart.
                using (Presentation pres = new Presentation())
                {
                    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                    // Link the chart to the external workbook without loading its data.
                    ((ChartData)chart.ChartData).SetExternalWorkbook(workbookPath, false);

                    // Save the presentation.
                    pres.Save(presentationPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation saved successfully: " + presentationPath);
            }
            catch (FileNotFoundException fnfEx)
            {
                Console.WriteLine("Required file not found: " + fnfEx.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}