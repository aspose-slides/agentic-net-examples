using System;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("DemoFile.pptx");

        // Create TIFF options and set a custom pixel format
        Aspose.Slides.Export.TiffOptions options = new Aspose.Slides.Export.TiffOptions();
        options.PixelFormat = Aspose.Slides.Export.ImagePixelFormat.Format8bppIndexed;

        // Save the presentation as a multi‑page TIFF using the specified options
        presentation.Save("Tiff_With_Custom_Image_Pixel_Format_out.tiff", Aspose.Slides.Export.SaveFormat.Tiff, options);

        // Clean up resources
        presentation.Dispose();
    }
}