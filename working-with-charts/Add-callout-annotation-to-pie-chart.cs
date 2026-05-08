using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 500, 400);
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 1, 1, 30));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 2, 1, 50));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 3, 1, 20));
            series.Labels.DefaultDataLabelFormat.ShowValue = true;
            series.Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
            presentation.Save("PieChartWithCallout.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}