using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Read the OLE data (e.g., an Excel file) from disk
        byte[] excelData = System.IO.File.ReadAllBytes("sample.xlsx");

        // Create embedded data info for the OLE object
        Aspose.Slides.IOleEmbeddedDataInfo dataInfo = new Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo(excelData, "xlsx");

        // Add an OLE object frame that occupies the whole slide
        Aspose.Slides.IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, dataInfo);

        // Lock the OLE object frame to prevent resizing and moving
        oleFrame.GraphicalObjectLock.SizeLocked = true;
        // If PositionLocked is available, uncomment the following line:
        // oleFrame.GraphicalObjectLock.PositionLocked = true;

        // Save the presentation in PPTX format
        pres.Save("LockedOleObject.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        pres.Dispose();
    }
}