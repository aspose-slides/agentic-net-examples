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
            string presentationPath = "input.pptx";
            string oleFilePath = "sample.xlsx";
            string outputPath = "output.pptx";

            // Load the existing presentation
            using (Presentation pres = new Presentation(presentationPath))
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Read the OLE file data into a byte array
                byte[] oleData = File.ReadAllBytes(oleFilePath);

                // Create embedded data info for the OLE object
                IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleData, "xlsx");

                // Define position and size for the OLE object frame (in points)
                float x = 100f;
                float y = 100f;
                float width = 400f;
                float height = 300f;

                // Add the OLE object frame to the slide
                IOleObjectFrame oleObject = slide.Shapes.AddOleObjectFrame(x, y, width, height, dataInfo);

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}