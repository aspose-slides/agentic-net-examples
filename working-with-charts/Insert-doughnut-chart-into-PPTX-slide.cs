using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DoughnutChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            var pres = new Aspose.Slides.Presentation();

            // Access the first slide
            var slide = pres.Slides[0];

            // Add a doughnut chart with sample position and size
            var chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Doughnut,
                50,   // X position
                50,   // Y position
                400,  // Width
                400   // Height
            );

            // Set the doughnut hole size (percentage of plot area)
            chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = (byte)50;

            // Save the presentation
            pres.Save("DoughnutChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}