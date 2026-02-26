using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation that contains a chart
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("ChartPresentation.pptx");

        // Create XPS export options
        Aspose.Slides.Export.XpsOptions options = new Aspose.Slides.Export.XpsOptions();
        // Convert all metafiles (including chart drawings) to PNG for better compatibility
        options.SaveMetafilesAsPng = true;

        // Save the presentation to XPS format using the specified options
        pres.Save("ChartPresentation_out.xps", Aspose.Slides.Export.SaveFormat.Xps, options);

        // Release resources
        pres.Dispose();
    }
}