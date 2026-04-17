using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column (bar) chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "A1", "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "A2", "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "A3", "Category 3"));

            // Add a series
            IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, "B0", "Series 1"), ChartType.ClusteredColumn);

            // Populate series with data points
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "B1", 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "B2", 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "B3", 30));

            // Enable data table beneath the chart
            chart.HasDataTable = true;

            // Save the presentation
            string outputPath = "BarChartWithDataTable.pptx";
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}