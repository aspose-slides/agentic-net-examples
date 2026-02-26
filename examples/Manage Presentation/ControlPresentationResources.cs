using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        // Path for the output presentation
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        // Create load options and configure to delete embedded binary objects (e.g., VBA, OLE, ActiveX)
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.DeleteEmbeddedBinaryObjects = true;

        // Open the presentation with the specified load options
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);

        // Save the presentation after processing
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}