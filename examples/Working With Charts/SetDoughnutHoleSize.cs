using System;

namespace DoughnutHoleSizeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a doughnut chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Doughnut,
                50f,   // X position
                50f,   // Y position
                400f,  // Width
                300f   // Height
            );

            // Set the doughnut hole size (percentage of plot area, 0-90)
            chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = (byte)50;

            // Save the presentation
            pres.Save("DoughnutHoleSize.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}