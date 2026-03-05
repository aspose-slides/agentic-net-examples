using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

namespace ChangeOleObjectData
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDir = @"C:\Data";
            string inputPresentationPath = Path.Combine(dataDir, "input.pptx");
            string newOleFilePath = Path.Combine(dataDir, "newImage.png");
            string outputPresentationPath = Path.Combine(dataDir, "output.pptx");

            // Load the existing presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPresentationPath))
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Cast the first shape to an OLE object frame
                Aspose.Slides.IOleObjectFrame oleObject = slide.Shapes[0] as Aspose.Slides.IOleObjectFrame;

                if (oleObject != null)
                {
                    // Read the new OLE data (e.g., an image) from file
                    byte[] newOleData = File.ReadAllBytes(newOleFilePath);

                    // Create an embedded data info object for the new data
                    Aspose.Slides.IOleEmbeddedDataInfo newDataInfo = new Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo(newOleData, "png");

                    // Replace the existing OLE embedded data with the new data
                    oleObject.SetEmbeddedData(newDataInfo);
                }

                // Save the modified presentation in PPTX format
                pres.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}