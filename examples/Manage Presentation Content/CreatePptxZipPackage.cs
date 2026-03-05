using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Configure PPTX save options to use ZIP64 format
        Aspose.Slides.Export.PptxOptions options = new Aspose.Slides.Export.PptxOptions();
        options.Zip64Mode = Aspose.Slides.Export.Zip64Mode.Always;

        // Save the presentation in PPTX format with the specified options
        presentation.Save("output.zip64.pptx", Aspose.Slides.Export.SaveFormat.Pptx, options);

        // Clean up resources
        presentation.Dispose();
    }
}