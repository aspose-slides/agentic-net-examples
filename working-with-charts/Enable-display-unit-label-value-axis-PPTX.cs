using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a clustered column chart on the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Activate the display unit label (Millions) for the vertical axis
            chart.Axes.VerticalAxis.DisplayUnit = Aspose.Slides.Charts.DisplayUnitType.Millions;

            // Save the presentation
            presentation.Save("DisplayUnitChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}