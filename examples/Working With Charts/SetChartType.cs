using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a chart with an initial type (ClusteredColumn)
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Change the chart type to Pie
        chart.Type = Aspose.Slides.Charts.ChartType.Pie;

        // Save the presentation
        presentation.Save("SetChartType_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}