using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace UpdateChartFromCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvPath = "data.csv";
            string outputPath = "UpdatedChart.pptx";

            if (!File.Exists(csvPath))
            {
                // CSV file does not exist
                Console.WriteLine("CSV file not found.");
                return;
            }

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a pie chart with sample data
            IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
            IChartData chartData = chart.ChartData;

            try
            {
                // Set external workbook (CSV) as data source; updateChartData set to false because format may not be supported
                ((ChartData)chartData).SetExternalWorkbook(csvPath, false);
            }
            catch (InvalidOperationException)
            {
                // Format not supported or workbook cannot be loaded
                Console.WriteLine("External workbook format not supported.");
            }

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}