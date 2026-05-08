using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

namespace SetBubbleBorderThickness
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "BubbleChartWithBorder.pptx";

            // Ensure any existing file is overwritten
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a bubble chart to the first slide
                IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50f, 50f, 600f, 400f);

                // Set bubble size representation (optional, demonstrates rule usage)
                chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Get the default worksheet index
                int defaultWorksheetIndex = 0;
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Add a series
                IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                // Add bubble data points (X, Y, Size)
                series.DataPoints.AddDataPointForBubbleSeries(1.0, 4.0, 30.0);
                series.DataPoints.AddDataPointForBubbleSeries(2.0, 5.0, 40.0);
                series.DataPoints.AddDataPointForBubbleSeries(3.0, 6.0, 50.0);

                // Set custom border thickness and color for each bubble
                foreach (IChartDataPoint point in series.DataPoints)
                {
                    // Set line width (border thickness)
                    point.Format.Line.Width = 2.0f;

                    // Set line fill to solid black
                    point.Format.Line.FillFormat.FillType = FillType.Solid;
                    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Black;
                }

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}