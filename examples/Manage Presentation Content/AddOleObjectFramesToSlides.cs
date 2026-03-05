using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Input OLE file (e.g., an Excel workbook) and output PPTX file paths
        string inputPath = "book1.xlsx";
        string outputPath = "OleEmbed_out.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Read the OLE file data into a byte array
        byte[] excelData = System.IO.File.ReadAllBytes(inputPath);

        // Create OLE embedded data info (specify file data and extension)
        Aspose.Slides.IOleEmbeddedDataInfo dataInfo = new Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo(excelData, "xlsx");

        // Add an OLE object frame that covers the entire slide
        Aspose.Slides.IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
            0, 0,
            pres.SlideSize.Size.Width,
            pres.SlideSize.Size.Height,
            dataInfo);

        // Save the presentation in PPTX format
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}