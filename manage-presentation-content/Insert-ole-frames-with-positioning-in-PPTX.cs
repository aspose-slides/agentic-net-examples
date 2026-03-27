using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

namespace InsertOleFrames
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the OLE source file (e.g., an Excel workbook)
            string oleFilePath = "sample.xlsx";

            // Verify that the OLE source file exists
            if (!File.Exists(oleFilePath))
            {
                Console.WriteLine("The OLE source file was not found: " + oleFilePath);
                return;
            }

            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Read the OLE file data into a byte array
                byte[] oleFileData = File.ReadAllBytes(oleFilePath);

                // Create the embedded data info (interface type from Aspose.Slides, implementation from Aspose.Slides.DOM.Ole)
                IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleFileData, "xlsx");

                // Add an OLE object frame with specific position and size
                // Parameters: x, y, width, height (all in points)
                IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(50f, 50f, 400f, 300f, dataInfo);

                // Optional: set additional properties (e.g., display as icon)
                oleObjectFrame.IsObjectIcon = false;

                // Save the presentation to disk
                string outputPath = "OleObject_out.pptx";
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
        }
    }
}