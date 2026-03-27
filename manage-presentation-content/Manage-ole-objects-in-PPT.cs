using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

namespace ManageOleObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for the presentation and the OLE file to embed
            string presentationPath = "input.pptx";
            string oleFilePath = "sample.xlsx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            Presentation presentation;
            if (File.Exists(presentationPath))
            {
                presentation = new Presentation(presentationPath);
            }
            else
            {
                presentation = new Presentation();
            }

            // Access the first slide (creates one if the presentation is new)
            ISlide slide = presentation.Slides[0];

            // Add an OLE object if the OLE source file exists
            if (File.Exists(oleFilePath))
            {
                byte[] oleFileData = File.ReadAllBytes(oleFilePath);
                IOleEmbeddedDataInfo embedInfo = new OleEmbeddedDataInfo(oleFileData, "xlsx");
                // Add the OLE object frame to the slide
                IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(50, 50, 400, 300, embedInfo);
            }

            // Modify the first OLE object on the slide, if any
            foreach (IShape shape in slide.Shapes)
            {
                OleObjectFrame oleFrame = shape as OleObjectFrame;
                if (oleFrame != null)
                {
                    // Prepare new embedded data (replace with a different file if desired)
                    string newOleFilePath = "newSample.xlsx";
                    if (File.Exists(newOleFilePath))
                    {
                        byte[] newOleData = File.ReadAllBytes(newOleFilePath);
                        IOleEmbeddedDataInfo newEmbedInfo = new OleEmbeddedDataInfo(newOleData, "xlsx");
                        oleFrame.SetEmbeddedData(newEmbedInfo);
                    }
                    break; // Modify only the first OLE object
                }
            }

            // Remove the last OLE object on the slide, if any
            for (int i = slide.Shapes.Count - 1; i >= 0; i--)
            {
                OleObjectFrame oleFrame = slide.Shapes[i] as OleObjectFrame;
                if (oleFrame != null)
                {
                    slide.Shapes.RemoveAt(i);
                    break; // Remove only one OLE object
                }
            }

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}