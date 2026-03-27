using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

class Program
{
    static void Main(string[] args)
    {
        // Paths for the source presentation, new OLE file, and output presentation
        string presentationPath = "input.pptx";
        string newOleFilePath = "newData.xlsx";
        string outputPath = "output.pptx";

        // Verify that the source files exist
        if (!File.Exists(presentationPath))
        {
            Console.WriteLine("Presentation file not found: " + presentationPath);
            return;
        }
        if (!File.Exists(newOleFilePath))
        {
            Console.WriteLine("OLE data file not found: " + newOleFilePath);
            return;
        }

        // Load the presentation
        using (Presentation pres = new Presentation(presentationPath))
        {
            // Read the new OLE file data
            byte[] oleData = File.ReadAllBytes(newOleFilePath);

            // Create embedded data info (extension without the leading dot)
            IOleEmbeddedDataInfo embeddedInfo = new OleEmbeddedDataInfo(oleData, "xlsx");

            // Locate the first OleObjectFrame on the first slide
            ISlide slide = pres.Slides[0];
            OleObjectFrame oleFrame = null;
            foreach (IShape shape in slide.Shapes)
            {
                oleFrame = shape as OleObjectFrame;
                if (oleFrame != null)
                {
                    break;
                }
            }

            if (oleFrame != null)
            {
                // Update the OLE object's embedded data
                oleFrame.SetEmbeddedData(embeddedInfo);
                Console.WriteLine("OLE object data updated successfully.");
            }
            else
            {
                Console.WriteLine("No OLE object found on the first slide.");
            }

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}