using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

class Program
{
    static void Main()
    {
        // Define directories and file paths
        string dataDir = "Data";
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        string excelPath = Path.Combine(dataDir, "sample.xlsx");
        string outputPath = Path.Combine(dataDir, "OleObject_out.ppt");

        // Ensure the Excel file exists (create an empty placeholder if missing)
        if (!File.Exists(excelPath))
        {
            File.WriteAllBytes(excelPath, new byte[0]);
        }

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Read the Excel file into a byte array
        byte[] excelData = File.ReadAllBytes(excelPath);

        // Create OLE embedded data info (fully qualified type)
        Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo dataInfo = new Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo(excelData, "xlsx");

        // Add an OLE object frame to the slide (covering the whole slide)
        Aspose.Slides.IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(
            0,
            0,
            presentation.SlideSize.Size.Width,
            presentation.SlideSize.Size.Height,
            dataInfo);

        // Set the OLE object to display as an icon and give it a title
        oleObjectFrame.IsObjectIcon = true;
        oleObjectFrame.SubstitutePictureTitle = "Excel Document";

        // Save the presentation in PPT format
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);

        // Dispose the presentation to release resources
        presentation.Dispose();
    }
}