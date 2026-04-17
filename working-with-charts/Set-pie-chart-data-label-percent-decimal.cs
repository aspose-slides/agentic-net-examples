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
            Presentation presentation = new Presentation();
            ISlide slide = presentation.Slides[0];
            IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 400);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

            // Add series and data points
            IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 1, 1, 30));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 2, 1, 50));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 3, 1, 20));

            // Set data label format to display percentages with one decimal place
            series.Labels.DefaultDataLabelFormat.ShowValue = true;
            series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
            series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";

            // Save the presentation
            presentation.Save("PieChartWithPercentage.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}