using System;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load the presentation from a file
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Create a full‑scale thumbnail image of the slide
        Aspose.Slides.IImage thumbnail = slide.GetImage(1f, 1f);

        // Save the thumbnail as a PNG file
        thumbnail.Save("thumbnail.png", ImageFormat.Png);

        // Save the presentation (required by the authoring rule)
        pres.Save("output.pptx", SaveFormat.Pptx);

        // Clean up resources
        thumbnail.Dispose();
        pres.Dispose();
    }
}