using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManageOleObjectFrames
{
    class Program
    {
        static void Main()
        {
            // Path to the source PPT presentation
            System.String inputPath = "input.ppt";
            // Path to the output PPT presentation
            System.String outputPath = "output.ppt";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Iterate through all shapes on the slide
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                // Try to cast the shape to an OLE object frame
                Aspose.Slides.IOleObjectFrame oleFrame = shape as Aspose.Slides.IOleObjectFrame;
                if (oleFrame != null)
                {
                    // Output basic information about the OLE object
                    Console.WriteLine("Found OLE Object Frame:");
                    Console.WriteLine(" - Alternative Text: " + oleFrame.AlternativeText);
                    Console.WriteLine(" - Link Path (Relative): " + oleFrame.LinkPathRelative);
                    Console.WriteLine(" - Embedded File Name: " + oleFrame.EmbeddedFileName);

                    // If the OLE object is embedded, extract its data
                    if (oleFrame.IsObjectLink == false && oleFrame.EmbeddedData != null)
                    {
                        // Get the embedded file data and its extension
                        System.Byte[] embeddedData = oleFrame.EmbeddedData.EmbeddedFileData;
                        System.String fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

                        // Build a file name for the extracted content
                        System.String extractedFileName = "extracted_ole" + fileExtension;

                        // Write the embedded data to disk
                        using (System.IO.FileStream fileStream = new System.IO.FileStream(extractedFileName, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.Read))
                        {
                            fileStream.Write(embeddedData, 0, embeddedData.Length);
                        }

                        Console.WriteLine(" - Extracted embedded data to: " + extractedFileName);
                    }
                }
            }

            // Save the (potentially modified) presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);
            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}