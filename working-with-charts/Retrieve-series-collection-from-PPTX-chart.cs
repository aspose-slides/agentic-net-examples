using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace RetrieveSeriesCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Assume the first shape on the first slide is a chart
                IChart chart = pres.Slides[0].Shapes[0] as IChart;
                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                    return;
                }

                // Retrieve the series collection
                IChartSeriesCollection seriesCollection = chart.ChartData.Series;
                Console.WriteLine("Existing series count: " + seriesCollection.Count);

                // Iterate through existing series and display their names
                for (int i = 0; i < seriesCollection.Count; i++)
                {
                    IChartSeries series = seriesCollection[i];
                    // Use AsLiteralString if the name is stored as a literal, otherwise fallback to ToString()
                    string seriesName = series.Name.AsLiteralString;
                    if (string.IsNullOrEmpty(seriesName))
                    {
                        seriesName = series.Name.ToString();
                    }
                    Console.WriteLine("Series " + i + " name: " + seriesName);
                }

                // Add a new series to the chart
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;
                // Create a cell that holds the new series name
                IChartDataCell newSeriesNameCell = workbook.GetCell(defaultWorksheetIndex, 0, seriesCollection.Count, "New Series");
                IChartSeries newSeries = seriesCollection.Add(newSeriesNameCell, chart.Type);

                // Add data points to the new series (using literal values)
                newSeries.DataPoints.AddDataPointForBarSeries(10);
                newSeries.DataPoints.AddDataPointForBarSeries(20);
                newSeries.DataPoints.AddDataPointForBarSeries(30);

                Console.WriteLine("Added new series with name: " + newSeries.Name.AsLiteralString);

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
        }
    }
}