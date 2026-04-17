using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart to the slide
            IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 400f, 300f);

            // Render the slide (which contains the chart) to a JPEG image in a memory stream with quality 80
            using (MemoryStream imageStream = new MemoryStream())
            {
                try
                {
                    IImage image = slide.GetImage(1f, 1f);
                    image.Save(imageStream, Aspose.Slides.ImageFormat.Jpeg, 80);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
            }

            // Save the presentation before exiting
            pres.Save("ChartPresentation.pptx", SaveFormat.Pptx);
        }
    }
}