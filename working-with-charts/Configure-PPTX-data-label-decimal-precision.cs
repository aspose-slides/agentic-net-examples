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
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Remove default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));

            // Add series
            IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
            IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

            // Populate series with data points
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 12.345));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 67.891));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 23.456));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 78.012));

            // Enable value display for data labels and set precision to two decimal places
            series1.Labels.DefaultDataLabelFormat.ShowValue = true;
            series1.Labels.DefaultDataLabelFormat.NumberFormat = "0.00";

            series2.Labels.DefaultDataLabelFormat.ShowValue = true;
            series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.00";

            // Save the presentation
            pres.Save("ChartDataLabelPrecision.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}