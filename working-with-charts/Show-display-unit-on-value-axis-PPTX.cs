using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DisplayUnitExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a clustered column chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(
                ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Enable display unit label (e.g., Millions) on the vertical axis
            chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

            // Save the presentation
            string outputPath = "DisplayUnitChart.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}