using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DuplicateChartSeries
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();
            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

            // Add the original series
            IChartSeries originalSeries = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Original Series"), chart.Type);
            // Populate original series data points
            originalSeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
            originalSeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 35));
            originalSeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 15));

            // Duplicate the series for comparative overlay
            IChartSeries duplicateSeries = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Duplicate Series"), chart.Type);
            // Modify data points (e.g., increase each value by 5)
            duplicateSeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 25));
            duplicateSeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 40));
            duplicateSeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 20));

            // Optional: adjust series overlap for better visual comparison
            if (originalSeries.Overlap == 0)
            {
                originalSeries.ParentSeriesGroup.Overlap = 30; // 30% overlap
                duplicateSeries.ParentSeriesGroup.Overlap = 30;
            }

            // Save the presentation
            try
            {
                presentation.Save("DuplicatedSeriesChart.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported exception
                // Format not supported
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}