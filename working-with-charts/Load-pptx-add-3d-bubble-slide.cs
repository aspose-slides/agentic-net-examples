using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace BubbleChartDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                // Input file not found; exit the program
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the existing presentation
                Presentation presentation = new Presentation(inputPath);

                // Add a new empty slide based on the first layout slide
                ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

                // Add a 3‑D bubble chart to the new slide
                IChart chart = newSlide.Shapes.AddChart(ChartType.Bubble, 50f, 50f, 600f, 400f);

                // Configure bubble size representation (Width) – using the provided rule
                chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;

                // Configure bubble size scaling – using the provided rule
                chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150; // 150% of default size

                // Clear default sample data
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Access the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category C"));

                // Add a series
                IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

                // Add data points for the bubble series (X, Y, Size)
                series.DataPoints.AddDataPointForBubbleSeries(
                    workbook.GetCell(defaultWorksheetIndex, 1, 1, 10.0),   // X value
                    workbook.GetCell(defaultWorksheetIndex, 1, 2, 20.0),   // Y value
                    workbook.GetCell(defaultWorksheetIndex, 1, 3, 5.0));   // Bubble size

                series.DataPoints.AddDataPointForBubbleSeries(
                    workbook.GetCell(defaultWorksheetIndex, 2, 1, 15.0),
                    workbook.GetCell(defaultWorksheetIndex, 2, 2, 25.0),
                    workbook.GetCell(defaultWorksheetIndex, 2, 3, 8.0));

                series.DataPoints.AddDataPointForBubbleSeries(
                    workbook.GetCell(defaultWorksheetIndex, 3, 1, 12.0),
                    workbook.GetCell(defaultWorksheetIndex, 3, 2, 22.0),
                    workbook.GetCell(defaultWorksheetIndex, 3, 3, 6.0));

                // Enable 3‑D effect for each bubble data point
                foreach (IChartDataPoint point in series.DataPoints)
                {
                    point.IsBubble3D = true;
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (ArgumentException)
            {
                // Handle unsupported file format
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}