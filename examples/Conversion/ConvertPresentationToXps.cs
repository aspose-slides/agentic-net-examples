using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the source presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Create XPS options with custom settings
        Aspose.Slides.Export.XpsOptions options = new Aspose.Slides.Export.XpsOptions();
        options.SaveMetafilesAsPng = true;      // Convert metafiles to PNG
        options.DrawSlidesFrame = true;         // Draw black frame around each slide

        // Save the presentation as XPS using the custom options
        pres.Save("output.xps", Aspose.Slides.Export.SaveFormat.Xps, options);

        // Release resources
        pres.Dispose();
    }
}