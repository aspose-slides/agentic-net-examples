using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Save the presentation to XPS using default settings
        pres.Save("output_default.xps", Aspose.Slides.Export.SaveFormat.Xps);

        // Create XpsOptions with custom settings
        Aspose.Slides.Export.XpsOptions options = new Aspose.Slides.Export.XpsOptions();
        options.SaveMetafilesAsPng = true; // Convert metafiles to PNG

        // Save the presentation to XPS using the custom options
        pres.Save("output_custom.xps", Aspose.Slides.Export.SaveFormat.Xps, options);
    }
}