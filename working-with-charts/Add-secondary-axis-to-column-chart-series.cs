using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Get the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                // Add primary series
                IChartSeries primarySeries = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Primary Series"), ChartType.ClusteredColumn);
                primarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
                primarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
                primarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

                // Add secondary series
                IChartSeries secondarySeries = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Secondary Series"), ChartType.ClusteredColumn);
                secondarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
                secondarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
                secondarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));

                // Map the secondary series to the secondary axis
                secondarySeries.PlotOnSecondAxis = true;

                // Save the presentation
                presentation.Save("ColumnChartWithSecondaryAxis.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported
            }
        }
    }
}