using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

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
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Try to get the first chart on the slide
                Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;

                // If no chart exists, add a new clustered column chart
                if (chart == null)
                {
                    chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);
                }

                // Get the chart data workbook and default worksheet index
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;

                // -----------------------------------------------------------------
                // Add a new series to the chart
                // -----------------------------------------------------------------
                Aspose.Slides.Charts.IChartSeries newSeries = chart.ChartData.Series.Add("New Series", chart.Type);
                // Add three data points with literal values
                newSeries.DataPoints.AddDataPointForBarSeries(15);
                newSeries.DataPoints.AddDataPointForBarSeries(30);
                newSeries.DataPoints.AddDataPointForBarSeries(45);

                // -----------------------------------------------------------------
                // Modify an existing series (change a data point value)
                // -----------------------------------------------------------------
                if (chart.ChartData.Series.Count > 0)
                {
                    Aspose.Slides.Charts.IChartSeries firstSeries = chart.ChartData.Series[0];
                    if (firstSeries.DataPoints.Count > 0)
                    {
                        // Set the first data point value to 99
                        firstSeries.DataPoints[0].Value.Data = 99;
                    }
                }

                // -----------------------------------------------------------------
                // Remove a series from the chart (if there are at least two series)
                // -----------------------------------------------------------------
                if (chart.ChartData.Series.Count > 1)
                {
                    // Remove the second series (index 1)
                    chart.ChartData.Series.RemoveAt(1);
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            Console.WriteLine("Chart manipulation completed. Output saved to: " + outputPath);
        }
    }
}