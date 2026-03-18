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

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f,   // x-coordinate
                50f,   // y-coordinate
                500f,  // width
                400f   // height
            );

            // Set the vertical axis display unit to millions
            chart.Axes.VerticalAxis.DisplayUnit = Aspose.Slides.Charts.DisplayUnitType.Millions;

            // Get the first series (sample data is already added)
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Get the label of the first data point
            Aspose.Slides.Charts.IDataLabel dataLabel = series.DataPoints[0].Label;

            // Adjust label position using fractions of the chart size (float literals)
            dataLabel.X = 0.2f; // 20% from the left edge of the chart
            dataLabel.Y = 0.3f; // 30% from the top edge of the chart

            // Save the presentation
            presentation.Save("AdjustedLabels.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}