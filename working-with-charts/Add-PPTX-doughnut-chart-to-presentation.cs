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
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a doughnut chart to the slide (x, y, width, height)
            IChart chart = slide.Shapes.AddChart(ChartType.Doughnut, 50f, 50f, 400f, 400f);

            // Set the doughnut hole size (percentage of plot area, 10-90)
            chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = (byte)50;

            // Save the presentation
            pres.Save("DoughnutChart.pptx", SaveFormat.Pptx);
        }
    }
}