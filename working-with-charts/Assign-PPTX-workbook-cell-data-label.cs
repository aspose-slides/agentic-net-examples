using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = pres.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 0, 0, 500, 400);
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;
            Aspose.Slides.Charts.IChartDataCell labelCell = workbook.GetCell(defaultWorksheetIndex, 1, 1, "Custom Label");
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
            Aspose.Slides.Charts.IChartDataPoint point = series.DataPoints[0];
            Aspose.Slides.Charts.IDataLabel dataLabel = point.Label;
            dataLabel.ValueFromCell = labelCell;
            dataLabel.DataLabelFormat.ShowLabelValueFromCell = true;
            pres.Save("ChartLabelFromCell.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}