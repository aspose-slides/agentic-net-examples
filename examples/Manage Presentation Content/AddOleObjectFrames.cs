using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

class Program
{
    static void Main()
    {
        // Define output directory and ensure it exists
        string outDir = "Output";
        if (!Directory.Exists(outDir))
        {
            Directory.CreateDirectory(outDir);
        }

        // Input OLE file (e.g., an Excel file) and output presentation paths
        string inputFile = Path.Combine(outDir, "sample.xlsx");
        string outputFile = Path.Combine(outDir, "OleObject_out.ppt");

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Read the OLE file data into a byte array
        byte[] excelData = File.ReadAllBytes(inputFile);

        // Create OLE embedded data info (file data and extension)
        Aspose.Slides.IOleEmbeddedDataInfo dataInfo = new Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo(excelData, "xlsx");

        // Add an OLE object frame that covers the entire slide
        Aspose.Slides.IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(
            0,
            0,
            presentation.SlideSize.Size.Width,
            presentation.SlideSize.Size.Height,
            dataInfo);

        // Save the presentation in PPT format as required
        presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Ppt);

        // Dispose the presentation to release resources
        presentation.Dispose();
    }
}