using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = pres.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();
            int defaultWorksheetIndex = 0;
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category C"));
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), Aspose.Slides.Charts.ChartType.Pie);
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 30));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 20));
            series.DataPoints[1].Explosion = 20;
            chart.Legend.X = 560f;
            chart.Legend.Y = 50f;
            chart.Legend.Width = 150f;
            chart.Legend.Height = 300f;
            pres.Save("CustomPieChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException ex)
        {
            // Input file not found (not applicable here)
        }
        catch (System.Exception ex)
        {
            // Handle other exceptions (e.g., unsupported format)
        }
    }
}