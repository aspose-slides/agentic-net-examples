using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the external Excel workbook
            string workbookPath = "externalData.xlsx";

            // Create the external workbook if it does not exist
            if (!File.Exists(workbookPath))
            {
                // Create a temporary presentation to generate chart data workbook
                using (Aspose.Slides.Presentation tempPres = new Aspose.Slides.Presentation())
                {
                    // Add a sample chart
                    Aspose.Slides.Charts.IChart tempChart = tempPres.Slides[0].Shapes.AddChart(
                        Aspose.Slides.Charts.ChartType.ClusteredColumn, 0, 0, 400, 300);

                    // Access chart data
                    Aspose.Slides.Charts.IChartData tempChartData = tempChart.ChartData;

                    // Clear default series and categories
                    tempChartData.Series.Clear();
                    tempChartData.Categories.Clear();

                    // Index of the default worksheet
                    int defaultWorksheetIndex = 0;

                    // Get the workbook factory
                    Aspose.Slides.Charts.IChartDataWorkbook workbook = tempChartData.ChartDataWorkbook;

                    // Add series
                    tempChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), tempChart.Type);
                    tempChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), tempChart.Type);

                    // Add categories
                    tempChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                    tempChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));

                    // Populate data points for the first series
                    Aspose.Slides.Charts.IChartSeries series0 = tempChartData.Series[0];
                    series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
                    series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));

                    // Populate data points for the second series
                    Aspose.Slides.Charts.IChartSeries series1 = tempChartData.Series[1];
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 40));

                    // Write the internal workbook to a file
                    using (MemoryStream ms = tempChartData.ReadWorkbookStream())
                    {
                        using (FileStream fs = new FileStream(workbookPath, FileMode.Create, FileAccess.Write))
                        {
                            ms.WriteTo(fs);
                        }
                    }
                }
            }

            // Create the final presentation and attach the external workbook
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Add a chart that will use the external workbook as its data source
                Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 400, 300);

                // Set the external workbook (do not update chart data immediately)
                ((Aspose.Slides.Charts.ChartData)chart.ChartData).SetExternalWorkbook(workbookPath, false);

                // Save the presentation
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
    }
}