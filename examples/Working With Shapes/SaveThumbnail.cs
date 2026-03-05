using System;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load an existing presentation
        Presentation pres = new Presentation("input.pptx");

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Generate a full‑scale thumbnail image of the slide
        IImage thumbnail = slide.GetImage(1f, 1f);

        // Save the thumbnail to disk with a chosen file name
        thumbnail.Save("slide_thumbnail.jpg", ImageFormat.Jpeg);

        // Save the presentation (ensuring any changes are persisted)
        pres.Save("output.pptx", SaveFormat.Pptx);

        // Clean up resources
        thumbnail.Dispose();
        pres.Dispose();
    }
}