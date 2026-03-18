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

            // Access the first slide's shape collection
            Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

            // Add a sample chart to the slide
            Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 0, 0, 500, 400);

            // Iterate through all series in the chart
            Aspose.Slides.Charts.IChartSeriesCollection seriesCollection = chart.ChartData.Series;
            for (int i = 0; i < seriesCollection.Count; i++)
            {
                Aspose.Slides.Charts.IChartSeries series = seriesCollection[i];

                // Apply a default marker style (e.g., Circle) to each series
                series.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Circle;
                series.Marker.Size = 5; // optional size setting
            }

            // Save the presentation
            presentation.Save("Output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}