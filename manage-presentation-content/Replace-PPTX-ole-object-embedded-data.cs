using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

class Program
{
    static void Main()
    {
        // Paths for input presentation, output presentation and new OLE data file
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string newOleFilePath = "newData.xlsx";

        try
        {
            // Load the existing presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Cast the first shape to OleObjectFrame (assumes the OLE object is at index 0)
                OleObjectFrame oleObject = slide.Shapes[0] as OleObjectFrame;

                if (oleObject != null)
                {
                    // Read the new OLE file data
                    byte[] newData = File.ReadAllBytes(newOleFilePath);

                    // Create embedded data info with the new data and its file extension
                    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(newData, "xlsx");

                    // Replace the embedded data of the OLE object
                    oleObject.SetEmbeddedData(dataInfo);
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}