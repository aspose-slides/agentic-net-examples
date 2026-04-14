using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetBubbleSizeRepresentation
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a bubble chart with sample data
            IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Bubble,
                0f,
                0f,
                500f,
                400f);

            // Get the first series group of the chart
            IChartSeriesGroup seriesGroup = chart.ChartData.SeriesGroups[0];

            // Set bubble size representation to Width
            seriesGroup.BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

            // Save the presentation
            pres.Save("SetBubbleSizeRepresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}