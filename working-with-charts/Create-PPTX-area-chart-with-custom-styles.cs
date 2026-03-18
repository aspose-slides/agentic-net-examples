using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AreaChartExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add an Area chart
                IChart chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 500, 400);

                // Set chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Sample Area Chart");
                chart.ChartTitle.TextFormat.PortionFormat.FontHeight = 20f;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Get the chart data workbook
                int defaultWorksheetIndex = 0;
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                // Add first series and its data points
                IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), ChartType.Area);
                series1.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
                series1.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
                series1.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));
                series1.ParentSeriesGroup.IsColorVaried = true; // Enable automatic slice colors

                // Add second series and its data points
                IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), ChartType.Area);
                series2.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 15));
                series2.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 25));
                series2.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 35));
                series2.ParentSeriesGroup.IsColorVaried = true; // Enable automatic slice colors

                // Customize axes visibility
                chart.Axes.VerticalAxis.IsVisible = false;
                chart.Axes.HorizontalAxis.IsVisible = true;

                // Set legend position
                chart.Legend.Position = LegendPositionType.Right;

                // Save the presentation
                presentation.Save("AreaChartPresentation.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}