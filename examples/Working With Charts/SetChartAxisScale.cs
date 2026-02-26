using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 450, 300);

        // Set vertical axis scale manually
        chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
        chart.Axes.VerticalAxis.MinValue = 0;
        chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
        chart.Axes.VerticalAxis.MaxValue = 200;
        chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
        chart.Axes.VerticalAxis.MajorUnit = 20;

        // Optional: ensure categories are placed between axis ticks
        chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

        // Save the presentation before exiting
        presentation.Save("SetChartAxisScale_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}