using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

namespace ManagePresentationBlob
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for source presentation and data files
            string sourcePresentationPath = "source.pptx";
            string extractedOlePath = "extractedOle";
            string newOleDataPath = "newData.xlsx";
            string modifiedOleDataPath = "modifiedData.docx";
            string outputPresentationPath = "output.pptx";

            // Verify that the source presentation exists
            if (!File.Exists(sourcePresentationPath))
            {
                Console.WriteLine("Source presentation not found: " + sourcePresentationPath);
                return;
            }

            // Load the presentation
            using (Presentation pres = new Presentation(sourcePresentationPath))
            {
                // -------------------------------------------------
                // 1. Extract embedded OLE data from the first OLE object (if any)
                // -------------------------------------------------
                ISlide firstSlide = pres.Slides[0];
                OleObjectFrame oleFrame = firstSlide.Shapes[0] as OleObjectFrame;
                if (oleFrame != null && oleFrame.EmbeddedData != null)
                {
                    byte[] oleData = oleFrame.EmbeddedData.EmbeddedFileData;
                    string oleExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
                    string extractedFilePath = extractedOlePath + oleExtension;

                    using (FileStream fs = new FileStream(extractedFilePath, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(oleData, 0, oleData.Length);
                    }

                    Console.WriteLine("Extracted OLE data to: " + extractedFilePath);
                }

                // -------------------------------------------------
                // 2. Insert a new OLE object frame with external data (if file exists)
                // -------------------------------------------------
                if (File.Exists(newOleDataPath))
                {
                    byte[] newOleBytes = File.ReadAllBytes(newOleDataPath);
                    IOleEmbeddedDataInfo newOleInfo = new OleEmbeddedDataInfo(newOleBytes, "xlsx");

                    // Add the OLE object frame to the first slide
                    IOleObjectFrame insertedOle = firstSlide.Shapes.AddOleObjectFrame(
                        100f,   // X position
                        100f,   // Y position
                        400f,   // Width
                        300f,   // Height
                        newOleInfo);

                    Console.WriteLine("Inserted new OLE object frame.");
                }

                // -------------------------------------------------
                // 3. Modify existing OLE object data (if file exists)
                // -------------------------------------------------
                if (oleFrame != null && File.Exists(modifiedOleDataPath))
                {
                    byte[] modifiedOleBytes = File.ReadAllBytes(modifiedOleDataPath);
                    IOleEmbeddedDataInfo modifiedOleInfo = new OleEmbeddedDataInfo(modifiedOleBytes, "docx");

                    // Replace the embedded data
                    oleFrame.SetEmbeddedData(modifiedOleInfo);
                    Console.WriteLine("Modified existing OLE object data.");
                }

                // -------------------------------------------------
                // Save the updated presentation
                // -------------------------------------------------
                pres.Save(outputPresentationPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPresentationPath);
            }
        }
    }
}