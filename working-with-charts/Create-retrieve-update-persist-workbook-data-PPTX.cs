using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartWorkbookDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define directories and file paths
            string dataDir = "Data";
            Directory.CreateDirectory(dataDir);
            string workbookPath = Path.Combine(dataDir, "chartData.xlsx");
            string presentationPath = Path.Combine(dataDir, "ChartWorkbookDemo.pptx");

            // Ensure the external workbook exists (create empty if missing)
            if (!File.Exists(workbookPath))
            {
                File.WriteAllBytes(workbookPath, new byte[0]);
            }

            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a pie chart to the first slide
            IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

            // Access the chart data
            IChartData chartData = chart.ChartData;

            // Link the chart to the external workbook without loading data (workbook may be empty)
            ((ChartData)chartData).SetExternalWorkbook(workbookPath, false);

            // Retrieve the workbook associated with the chart
            IChartDataWorkbook workbook = chartData.ChartDataWorkbook;

            // Update workbook cells (add categories and series data)
            // Add a category name in cell A1 (row 0, column 0)
            workbook.GetCell(0, 0, 0, "Category 1");
            // Add a series name in cell B1 (row 0, column 1)
            workbook.GetCell(0, 0, 1, "Series 1");

            // Update a data point value in the chart (first series, first point)
            IChartSeries series = chartData.Series[0];
            series.DataPoints[0].Value.Data = 75;

            // Save the presentation
            pres.Save(presentationPath, SaveFormat.Pptx);
        }
    }
}