using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a doughnut chart to the slide (position and size in points)
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Doughnut,
            50f,   // X position
            50f,   // Y position
            400f,  // Width
            400f   // Height
        );

        // Set the doughnut hole size (percentage of the plot area, e.g., 50%)
        chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = (byte)50;

        // Save the presentation
        pres.Save("DoughnutChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}