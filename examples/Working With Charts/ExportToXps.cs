using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Create XPS export options
        Aspose.Slides.Export.XpsOptions options = new Aspose.Slides.Export.XpsOptions();
        // Example option: convert metafiles to PNG
        options.SaveMetafilesAsPng = true;

        // Save the presentation as XPS using the specified options
        presentation.Save("output.xps", Aspose.Slides.Export.SaveFormat.Xps, options);

        // Release resources
        presentation.Dispose();
    }
}