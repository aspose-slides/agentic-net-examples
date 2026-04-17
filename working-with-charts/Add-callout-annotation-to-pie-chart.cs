using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a pie chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie, 50, 50, 500, 400);

            // Prepare chart data
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 1, 1, 30));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 2, 1, 50));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 3, 1, 20));

            // Add callout annotation to the second data point (index 1)
            chart.ChartData.Series[0].Labels[1].DataLabelFormat.ShowLabelAsDataCallout = true;
            chart.ChartData.Series[0].Labels[1].DataLabelFormat.ShowValue = true;

            // Save the presentation
            presentation.Save("PieChartCallout.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
        }
    }
}