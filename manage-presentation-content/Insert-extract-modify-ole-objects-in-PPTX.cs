using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

namespace OleObjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input presentation, OLE source file, extracted output, and final presentation
            string inputPresentationPath = "input.pptx";
            string oleSourcePath = "sample.xlsx";
            string extractedOlePath = "extracted.xlsx";
            string outputPresentationPath = "output.pptx";

            // Verify that the input files exist
            if (!File.Exists(inputPresentationPath))
            {
                Console.WriteLine("Input presentation file not found: " + inputPresentationPath);
                return;
            }

            if (!File.Exists(oleSourcePath))
            {
                Console.WriteLine("OLE source file not found: " + oleSourcePath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPresentationPath))
            {
                // Read the OLE file data
                byte[] oleFileData = File.ReadAllBytes(oleSourcePath);

                // Create embedded data info (use fully‑qualified OleEmbeddedDataInfo)
                IOleEmbeddedDataInfo embedInfo = new OleEmbeddedDataInfo(oleFileData, "xlsx");

                // Insert a new OLE object frame on the first slide
                ISlide firstSlide = presentation.Slides[0];
                IOleObjectFrame oleObjectFrame = firstSlide.Shapes.AddOleObjectFrame(50, 50, 400, 300, embedInfo);

                // Extract the embedded OLE data from the newly added object
                byte[] extractedData = oleObjectFrame.EmbeddedData.EmbeddedFileData;
                File.WriteAllBytes(extractedOlePath, extractedData);
                Console.WriteLine("Extracted OLE data saved to: " + extractedOlePath);

                // Modify the OLE object by embedding new data (for demonstration, reuse the same file)
                // Create a new embedded data info instance
                IOleEmbeddedDataInfo newEmbedInfo = new OleEmbeddedDataInfo(oleFileData, "xlsx");
                // Update the OLE object with the new data
                oleObjectFrame.SetEmbeddedData(newEmbedInfo);
                Console.WriteLine("OLE object data has been updated.");

                // Save the modified presentation
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPresentationPath);
            }
        }
    }
}