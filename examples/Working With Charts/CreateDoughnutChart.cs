using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide (index 0)
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a doughnut chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Doughnut,
            50f,   // X position
            50f,   // Y position
            400f,  // Width
            400f   // Height
        );

        // Set the size of the doughnut hole (percentage of the plot area)
        chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = (byte)50;

        // Save the presentation to a PPTX file
        pres.Save("DoughnutChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}