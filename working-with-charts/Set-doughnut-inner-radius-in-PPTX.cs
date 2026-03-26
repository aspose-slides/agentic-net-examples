using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var pres = new Aspose.Slides.Presentation();

        // Access the first slide
        var slide = pres.Slides[0];

        // Add a doughnut chart to the slide
        var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Doughnut, 50f, 50f, 400f, 400f);

        // Set the doughnut hole size (percentage of plot area, e.g., 50%)
        chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = (byte)50;

        // Save the presentation
        pres.Save("DoughnutHoleSize.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}