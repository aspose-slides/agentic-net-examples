using System;

class Program
{
    static void Main()
    {
        // Load the source PowerPoint presentation
        var presentation = new Aspose.Slides.Presentation("input.pptx");

        // Save the presentation to XPS using default settings
        presentation.Save("output_default.xps", Aspose.Slides.Export.SaveFormat.Xps);

        // Create XPS options and customize them
        var options = new Aspose.Slides.Export.XpsOptions();
        options.SaveMetafilesAsPng = true;

        // Save the presentation to XPS using custom options
        presentation.Save("output_custom.xps", Aspose.Slides.Export.SaveFormat.Xps, options);

        // Release resources
        presentation.Dispose();
    }
}