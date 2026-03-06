class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a doughnut chart to the slide (position 50,50; size 400x400)
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Doughnut,
            50f, 50f, 400f, 400f);

        // Set the doughnut hole size (percentage of plot area, 10-90)
        chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = (byte)50;

        // Save the presentation
        pres.Save("CustomizeDoughnutChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}