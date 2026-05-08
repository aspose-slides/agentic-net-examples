using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace RenderChartToMemoryStream
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a clustered column chart to the first slide
            IChart chart = pres.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0f, 0f, 500f, 400f);

            // (Optional) Customize chart data here if needed

            // Render the slide (which contains the chart) to an image
            IImage slideImage = pres.Slides[0].GetImage(1f, 1f);

            // Create a memory stream to hold the JPEG image
            MemoryStream jpegStream = new MemoryStream();

            try
            {
                // Save the image to the memory stream in JPEG format with quality 80
                slideImage.Save(jpegStream, Aspose.Slides.ImageFormat.Jpeg, 80);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle accordingly
            }

            // Reset stream position for further use
            jpegStream.Position = 0;

            // Save the presentation before exiting
            try
            {
                pres.Save("ChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception)
            {
                // Handle save errors (e.g., unsupported format)
            }

            // Clean up resources
            slideImage.Dispose();
            pres.Dispose();
        }
    }
}