using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace OleLinkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for the external OLE file and the output presentation
            string oleFilePath = "sample.xlsx";
            string outputPath = "LinkedOlePresentation.pptx";

            // Verify that the external OLE file exists
            if (!File.Exists(oleFilePath))
            {
                Console.WriteLine("The OLE source file does not exist: " + oleFilePath);
                return;
            }

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a linked OLE object frame (Excel sheet) to the slide
            // Class name for Excel OLE object is typically "Excel.Sheet"
            Aspose.Slides.IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
                50f,    // X position
                50f,    // Y position
                400f,   // Width
                300f,   // Height
                "Excel.Sheet", // OLE class name
                oleFilePath    // Path to the linked file
            );

            // Enable automatic updates when the presentation is opened
            oleFrame.UpdateAutomatic = true;

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            pres.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}