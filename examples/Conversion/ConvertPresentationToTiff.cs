using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        var sourcePath = "input.pptx";

        // Load the presentation
        using (var presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Create TIFF options with custom image size and DPI
            var options = new Aspose.Slides.Export.TiffOptions();
            options.ImageSize = new Size(1728, 1078); // custom dimensions
            options.DpiX = 200; // horizontal DPI
            options.DpiY = 100; // vertical DPI

            // Save the presentation as a TIFF file using the specified options
            presentation.Save("output.tiff", Aspose.Slides.Export.SaveFormat.Tiff, options);
        }
    }
}