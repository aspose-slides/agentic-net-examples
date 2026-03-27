using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        using (Presentation presentation = new Presentation(inputPath))
        {
            // Path to an allowed embedded file (e.g., an Excel workbook)
            string oleFilePath = "sample.xlsx";

            if (!File.Exists(oleFilePath))
            {
                Console.WriteLine("OLE file not found: " + oleFilePath);
                return;
            }

            // Read the file data
            byte[] oleData = File.ReadAllBytes(oleFilePath);

            // Create OLE embedded data info (allowed file type: xlsx)
            IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleData, "xlsx");

            // Add the OLE object to the first slide
            ISlide slide = presentation.Slides[0];
            slide.Shapes.AddOleObjectFrame(50f, 50f, 400f, 300f, dataInfo);

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}