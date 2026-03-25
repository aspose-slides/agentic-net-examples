using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace GenerateLineChart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file name
            const string outputPath = "LineChartPresentation.pptx";

            // Optional input template file path (first argument)
            string inputPath = args.Length > 0 ? args[0] : string.Empty;

            // Create or load presentation
            Presentation pres = null;
            try
            {
                if (!string.IsNullOrEmpty(inputPath))
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.WriteLine("Input file not found: " + inputPath);
                        return;
                    }
                    pres = new Presentation(inputPath);
                }
                else
                {
                    pres = new Presentation();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while creating/loading presentation: " + ex.Message);
                return;
            }

            // Ensure presentation is disposed at the end
            using (pres)
            {
                // Access first slide
                ISlide slide = pres.Slides[0];

                // Add a line chart
                IChart chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 500, 400);

                // Set chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Sample Line Chart");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
                chart.ChartTitle.Height = 20;

                // Remove default sample data
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Reference to the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                const int defaultWorksheetIndex = 0;

                // Add two series
                chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
                chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

                // Add three categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                // Populate first series data points
                IChartSeries series1 = chart.ChartData.Series[0];
                series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
                series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
                series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

                // Populate second series data points
                IChartSeries series2 = chart.ChartData.Series[1];
                series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 15));
                series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 25));
                series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 35));

                // Save the presentation
                try
                {
                    pres.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved successfully to " + outputPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while saving presentation: " + ex.Message);
                }
            }
        }
    }
}