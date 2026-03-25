using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartSeriesManipulation
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
            Presentation pres = new Presentation(inputPath);

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Assume the first shape is a chart
            IChart chart = slide.Shapes[0] as IChart;
            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
                pres.Dispose();
                return;
            }

            // Index of the default worksheet in the chart data workbook
            int defaultWorksheetIndex = 0;
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // -------------------------
            // Add a new series
            // -------------------------
            IChartSeries newSeries = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 3, "Series 3"),
                chart.Type);

            // Add data points to the new series
            newSeries.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 1, 3, 40));
            newSeries.DataPoints.AddDataPointForBarSeries(
                workbook.GetCell(defaultWorksheetIndex, 2, 3, 60));

            // -------------------------
            // Modify an existing series
            // -------------------------
            IChartSeries series0 = chart.ChartData.Series[0];
            // Change the value of the first data point
            series0.DataPoints[0].Value.Data = 25;

            // -------------------------
            // Remove a series
            // -------------------------
            // Remove the second series (index 1) if it exists
            if (chart.ChartData.Series.Count > 1)
            {
                chart.ChartData.Series.RemoveAt(1);
            }

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}