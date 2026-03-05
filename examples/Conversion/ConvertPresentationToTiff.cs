using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load the source presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Create TIFF export options
        Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();

        // Set compression type (default LZW)
        tiffOptions.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.Default;

        // Set custom DPI
        tiffOptions.DpiX = 200;
        tiffOptions.DpiY = 100;

        // Set custom image size
        tiffOptions.ImageSize = new System.Drawing.Size(1728, 1078);

        // Save the presentation as TIFF with the specified options
        presentation.Save("output.tiff", Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);

        // Save the original presentation before exiting (optional)
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}