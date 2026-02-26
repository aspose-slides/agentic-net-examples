using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

class Program
{
    static void Main()
    {
        // Paths to the source presentation, new OLE data file and output presentation
        string dataDir = "Data/";
        string inputPath = dataDir + "input.ppt";
        string newOlePath = dataDir + "newData.xlsx";
        string outputPath = dataDir + "output.ppt";

        // Load the existing presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Cast the first shape to an OLE object frame
            Aspose.Slides.IOleObjectFrame oleFrame = slide.Shapes[0] as Aspose.Slides.IOleObjectFrame;

            if (oleFrame != null)
            {
                // Read the new OLE file data
                byte[] oleData = System.IO.File.ReadAllBytes(newOlePath);

                // Create an embedded data info object for the new OLE data
                Aspose.Slides.IOleEmbeddedDataInfo newDataInfo = new Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo(oleData, "xlsx");

                // Replace the embedded data in the OLE object frame
                oleFrame.SetEmbeddedData(newDataInfo);
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);
        }
    }
}