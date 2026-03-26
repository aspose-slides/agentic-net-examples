using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetDoughnutHole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a doughnut chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Doughnut, 50, 50, 500, 400);

            // Set the inner radius (hole size) of the doughnut chart to 50%
            chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = (byte)50;

            // Save the presentation
            string outputPath = "DoughnutHole.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}