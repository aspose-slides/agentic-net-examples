using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartToTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a clustered column chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // Define high‑resolution TIFF options (300 DPI)
            Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
            tiffOptions.DpiX = 300u;
            tiffOptions.DpiY = 300u;

            // Render the slide (which contains the chart) to a TIFF image
            Aspose.Slides.IImage slideImage = presentation.Slides[0].GetImage(tiffOptions);

            // Save the TIFF image to disk
            slideImage.Save("ChartHighRes.tiff", Aspose.Slides.ImageFormat.Tiff);

            // Save the presentation (optional, but required before exit)
            presentation.Save("ChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();
        }
    }
}