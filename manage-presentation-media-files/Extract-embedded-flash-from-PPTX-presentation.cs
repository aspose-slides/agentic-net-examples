using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractFlashObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source presentation
                string sourcePath = "input.pptx";

                // Load the presentation (keep embedded binary objects)
                Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
                loadOptions.DeleteEmbeddedBinaryObjects = false;

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath, loadOptions))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                            // Check if the shape is an OLE object (Flash objects are stored as OLE)
                            Aspose.Slides.OleObjectFrame oleObject = shape as Aspose.Slides.OleObjectFrame;
                            if (oleObject != null)
                            {
                                // Verify that the OLE object is a Flash object by checking its ProgID
                                // Typical ProgID for Flash: "ShockwaveFlash.ShockwaveFlash"
                                if (oleObject.ObjectProgId != null && oleObject.ObjectProgId.Contains("ShockwaveFlash"))
                                {
                                    // Retrieve embedded data
                                    Aspose.Slides.IOleEmbeddedDataInfo embeddedData = oleObject.EmbeddedData;

                                    // Build output file name using original label and extension
                                    string fileExtension = embeddedData.EmbeddedFileExtension;
                                    string fileLabel = oleObject.EmbeddedFileLabel;
                                    if (string.IsNullOrEmpty(fileLabel))
                                    {
                                        fileLabel = "FlashObject_" + slideIndex + "_" + shapeIndex;
                                    }
                                    string outputFileName = fileLabel + fileExtension;

                                    // Write the embedded Flash file to disk
                                    using (FileStream fileStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
                                    {
                                        fileStream.Write(embeddedData.EmbeddedFileData, 0, embeddedData.EmbeddedFileData.Length);
                                    }

                                    // Optionally, preserve some metadata (e.g., alternative text) as a side‑car text file
                                    string metadataFileName = fileLabel + "_metadata.txt";
                                    using (StreamWriter writer = new StreamWriter(metadataFileName))
                                    {
                                        writer.WriteLine("SlideIndex: " + slideIndex);
                                        writer.WriteLine("ShapeIndex: " + shapeIndex);
                                        writer.WriteLine("ObjectProgId: " + oleObject.ObjectProgId);
                                        writer.WriteLine("AlternativeText: " + oleObject.AlternativeText);
                                        writer.WriteLine("IsObjectIcon: " + oleObject.IsObjectIcon);
                                    }
                                }
                            }
                        }
                    }

                    // Save the presentation (required by the task)
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}