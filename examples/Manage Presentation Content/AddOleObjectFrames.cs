using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Define directories and file paths
        string outputDir = "Output";
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }
        string inputOlePath = Path.Combine(outputDir, "sample.xlsx"); // Ensure this file exists
        string outputPptPath = Path.Combine(outputDir, "OleObject_out.ppt");

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Read the OLE file data into a byte array
        byte[] oleFileData = File.ReadAllBytes(inputOlePath);

        // Create embedded data info for the OLE object (extension without dot)
        Aspose.Slides.IOleEmbeddedDataInfo oleDataInfo = new Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo(oleFileData, "xlsx");

        // Add an OLE object frame that covers the whole slide
        Aspose.Slides.IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(
            0,
            0,
            presentation.SlideSize.Size.Width,
            presentation.SlideSize.Size.Height,
            oleDataInfo);

        // Save the presentation in PPT format
        presentation.Save(outputPptPath, Aspose.Slides.Export.SaveFormat.Ppt);

        // Dispose the presentation object
        presentation.Dispose();
    }
}