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

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Get the chart image (default size)
        Aspose.Slides.IImage chartImage = chart.GetImage();

        // Save the chart image as a high‑resolution JPEG (quality 100)
        try
        {
            chartImage.Save("ChartImage.jpg", Aspose.Slides.ImageFormat.Jpeg, 100);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Save the presentation before exiting
        presentation.Save("ChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}