using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string dataDir = @"C:\Data\";
            string presentationPath = Path.Combine(dataDir, "input.pptx");
            string newOleFilePath = Path.Combine(dataDir, "newData.xlsx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Load the presentation
            using (Presentation pres = new Presentation(presentationPath))
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Cast the first shape to an OLE object frame
                IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;
                if (oleFrame != null)
                {
                    // Read the new OLE file data
                    byte[] oleBytes = File.ReadAllBytes(newOleFilePath);

                    // Create embedded data info (extension without dot)
                    IOleEmbeddedDataInfo embeddedInfo = new OleEmbeddedDataInfo(oleBytes, "xlsx");

                    // Update the OLE object with the new data
                    oleFrame.SetEmbeddedData(embeddedInfo);
                }

                // Save the updated presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}