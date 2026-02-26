using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string dataDir = "Data";
        string inputFile = Path.Combine(dataDir, "sample.xlsx");
        string outputDir = "Output";
        string outputFile = Path.Combine(outputDir, "OleObjectPresentation.ppt");

        // Ensure the output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Read the Excel file into a byte array
        byte[] excelData = System.IO.File.ReadAllBytes(inputFile);

        // Create OLE embedded data info for the Excel file
        Aspose.Slides.IOleEmbeddedDataInfo dataInfo = new Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo(excelData, "xlsx");

        // Add an OLE object frame that covers the entire slide
        Aspose.Slides.IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(
            0,
            0,
            presentation.SlideSize.Size.Width,
            presentation.SlideSize.Size.Height,
            dataInfo);

        // Set the OLE object to be displayed as an icon and give it a title
        oleObjectFrame.IsObjectIcon = true;
        oleObjectFrame.SubstitutePictureTitle = "Excel Data";

        // Save the presentation in PPT format
        presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Ppt);

        // Dispose the presentation object
        presentation.Dispose();
    }
}