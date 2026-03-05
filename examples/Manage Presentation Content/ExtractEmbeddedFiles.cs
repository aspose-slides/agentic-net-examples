using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source PPTX file
        string inputPath = "input.pptx";
        // Directory where extracted embedded files will be saved
        string outputDir = "ExtractedFiles";

        // Ensure the output directory exists
        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Counter for naming extracted files
        int fileIndex = 0;

        // Iterate through all slides and shapes to find OLE object frames
        foreach (Aspose.Slides.ISlide slide in pres.Slides)
        {
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.OleObjectFrame)
                {
                    Aspose.Slides.OleObjectFrame oleFrame = shape as Aspose.Slides.OleObjectFrame;

                    // Get the embedded file data and its extension
                    byte[] embeddedData = oleFrame.EmbeddedData.EmbeddedFileData;
                    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

                    // Build the output file path
                    string outFilePath = Path.Combine(outputDir, "embedded_" + fileIndex + fileExtension);

                    // Write the embedded data to disk
                    using (FileStream fs = new FileStream(outFilePath, FileMode.Create, FileAccess.Write, FileShare.Read))
                    {
                        fs.Write(embeddedData, 0, embeddedData.Length);
                    }

                    fileIndex++;
                }
            }
        }

        // Save the presentation (required by authoring rules)
        pres.Save("output.pptx", SaveFormat.Pptx);
        pres.Dispose();
    }
}