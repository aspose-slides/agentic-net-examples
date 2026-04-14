using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 150f, 500f, 400f);

        // Move the legend to the top‑left corner of the chart
        chart.Legend.X = 0f;
        chart.Legend.Y = 0f;
        chart.Legend.Width = 100f;   // set desired width
        chart.Legend.Height = 50f;   // set desired height

        // Save the presentation
        presentation.Save("LegendTopLeft.pptx", SaveFormat.Pptx);
    }
}