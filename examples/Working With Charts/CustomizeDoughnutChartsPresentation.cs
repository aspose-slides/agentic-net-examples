using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

        // Set the doughnut hole size (percentage of the plot area)
        chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = (byte)50;

        // Save the presentation to a PPTX file
        pres.Save("CustomizedDoughnutChart_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}