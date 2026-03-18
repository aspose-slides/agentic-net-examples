using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartDataModification
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a clustered column chart
                    IChart chart = slide.Shapes.AddChart(
                        ChartType.ClusteredColumn,
                        50f, 50f, 500f, 400f);

                    // Get the chart data workbook
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                    int defaultWorksheetIndex = 0;

                    // Clear default series and categories
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Add new series
                    IChartSeries series1 = chart.ChartData.Series.Add(
                        workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                        ChartType.ClusteredColumn);
                    IChartSeries series2 = chart.ChartData.Series.Add(
                        workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"),
                        ChartType.ClusteredColumn);

                    // Add new categories
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A"));
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B"));
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category C"));

                    // Populate series1 with data points
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20.0));
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50.0));
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30.0));

                    // Populate series2 with data points
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 35.0));
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 15.0));
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 45.0));

                    // Update a specific data point value (e.g., change second point of series1 to 55)
                    IChartDataCell cellToUpdate = workbook.GetCell(defaultWorksheetIndex, 2, 1);
                    cellToUpdate.Value = 55.0;

                    // Update a category name (e.g., change "Category B" to "Category Beta")
                    IChartCategory categoryToUpdate = chart.ChartData.Categories[1];
                    categoryToUpdate.Value = workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category Beta");

                    // Save the presentation
                    presentation.Save("ModifiedChartPresentation.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}