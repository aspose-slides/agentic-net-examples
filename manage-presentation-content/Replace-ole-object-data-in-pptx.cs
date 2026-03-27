using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

class Program
{
    static void Main(string[] args)
    {
        // Define paths
        string dataDir = "Data" + Path.DirectorySeparatorChar;
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string newOlePath = Path.Combine(dataDir, "newOle.bin");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Verify input files exist
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input presentation not found: " + inputPath);
            return;
        }
        if (!File.Exists(newOlePath))
        {
            Console.WriteLine("New OLE data file not found: " + newOlePath);
            return;
        }

        // Load presentation
        using (Presentation pres = new Presentation(inputPath))
        {
            // Access the first slide and first shape (assumed to be an OLE object)
            ISlide slide = pres.Slides[0];
            IShape shape = slide.Shapes[0];
            OleObjectFrame oleFrame = shape as OleObjectFrame;

            if (oleFrame != null)
            {
                // Read new OLE data
                byte[] oleData = File.ReadAllBytes(newOlePath);
                // Create embedded data info (using .bin extension as example)
                IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleData, "bin");
                // Replace embedded data
                oleFrame.SetEmbeddedData(dataInfo);
            }

            // Save the updated presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}