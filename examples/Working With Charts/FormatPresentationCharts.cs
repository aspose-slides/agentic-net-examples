using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Get the series collection of the chart
        Aspose.Slides.Charts.IChartSeriesCollection seriesCollection = chart.ChartData.Series;

        // Iterate through each series and its data points to set a number format
        foreach (Aspose.Slides.Charts.ChartSeries seriesItem in seriesCollection)
        {
            foreach (Aspose.Slides.Charts.IChartDataPoint dataPoint in seriesItem.DataPoints)
            {
                // Set preset number format to percentage (0.00%)
                dataPoint.Value.AsCell.PresetNumberFormat = 10;
            }
        }

        // Save the presentation to a PPTX file
        presentation.Save("FormattedChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}