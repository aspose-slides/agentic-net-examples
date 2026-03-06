using System;
using System.IO;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation that contains a chart
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Assume the first shape on the first slide is a chart
        Aspose.Slides.IShape shape = pres.Slides[0].Shapes[0];
        Aspose.Slides.Charts.Chart chart = shape as Aspose.Slides.Charts.Chart;

        if (chart != null)
        {
            // Get the chart image (thumbnail) at default scale
            Aspose.Slides.IImage chartImage = chart.GetImage();

            // Save the chart image to a PNG file
            chartImage.Save("chart.png", ImageFormat.Png);
        }

        // Save the presentation (required before exit)
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        pres.Dispose();
    }
}