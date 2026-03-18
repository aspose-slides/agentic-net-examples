using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Access chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add series
            IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
            IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

            // Populate data points
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 30));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 10));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 60));

            // Configure vertical axis scaling
            IAxis verticalAxis = chart.Axes.VerticalAxis;
            verticalAxis.IsAutomaticMinValue = false;
            verticalAxis.IsAutomaticMaxValue = false;
            verticalAxis.MinValue = 0;
            verticalAxis.MaxValue = 100;
            verticalAxis.IsAutomaticMajorUnit = false;
            verticalAxis.MajorUnit = 20;
            verticalAxis.IsAutomaticMinorUnit = false;
            verticalAxis.MinorUnit = 5;

            // Optionally hide horizontal axis
            IAxis horizontalAxis = chart.Axes.HorizontalAxis;
            horizontalAxis.IsVisible = false;

            // Save the presentation
            presentation.Save("ChartAxisScaling_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}