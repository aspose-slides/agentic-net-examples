class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a chart to the slide (ClusteredColumn type)
        Aspose.Slides.Charts.IChart tempChart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Retrieve the chart from the shape collection
        Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes[0] as Aspose.Slides.Charts.IChart;

        // Edit the first data point of the first series
        if (chart != null)
        {
            chart.ChartData.Series[0].DataPoints[0].Value.Data = 123.45;
        }

        // Save the presentation
        pres.Save("EditedChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}