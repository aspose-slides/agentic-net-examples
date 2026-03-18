using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 400, 300);

            // Access the series collection
            Aspose.Slides.Charts.IChartSeriesCollection seriesCollection = chart.ChartData.Series;

            System.Console.WriteLine("Initial series count: " + seriesCollection.Count);

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add a new series
            Aspose.Slides.Charts.IChartDataCell seriesNameCell = workbook.GetCell(defaultWorksheetIndex, 0, 1, "New Series");
            Aspose.Slides.Charts.IChartSeries newSeries = seriesCollection.Add(seriesNameCell, chart.Type);

            // Populate the new series with data points
            newSeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
            newSeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
            newSeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

            System.Console.WriteLine("Series count after addition: " + seriesCollection.Count);

            // Remove the first series if it exists
            if (seriesCollection.Count > 0)
            {
                Aspose.Slides.Charts.IChartSeries firstSeries = seriesCollection[0];
                seriesCollection.Remove(firstSeries);
                System.Console.WriteLine("Series count after removal: " + seriesCollection.Count);
            }

            // Save the presentation
            presentation.Save("ChartSeriesDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}