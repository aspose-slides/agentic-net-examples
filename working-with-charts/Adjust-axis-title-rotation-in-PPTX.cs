using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartAxisRotationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a clustered column chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 450f, 300f);

            // Enable title for the vertical axis
            chart.Axes.VerticalAxis.HasTitle = true;

            // Set the rotation angle of the vertical axis title text
            chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90f;

            // Save the presentation
            presentation.Save("ChartAxisRotation.pptx", SaveFormat.Pptx);
        }
    }
}