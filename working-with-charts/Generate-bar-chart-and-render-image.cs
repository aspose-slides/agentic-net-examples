using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart (acts as a bar chart) to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);

        // Render the chart to an image
        Aspose.Slides.IImage chartImage = chart.GetImage();

        // Save the chart image as PNG
        chartImage.Save("chart.png", Aspose.Slides.ImageFormat.Png);

        // Save the presentation before exiting
        presentation.Save("BarChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}