using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        System.String sourcePath = "input.pptx";
        // Directory where extracted files will be saved
        System.String outputDir = "ExtractedFiles";

        // Verify that the source file exists
        if (!System.IO.File.Exists(sourcePath))
        {
            System.Console.WriteLine("Source file not found: " + sourcePath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(sourcePath);

        // Ensure the output directory exists
        if (!System.IO.Directory.Exists(outputDir))
            System.IO.Directory.CreateDirectory(outputDir);

        // Counter for naming extracted files
        System.Int32 fileIndex = 0;

        // Iterate through slides and shapes to find OLE object frames
        foreach (Aspose.Slides.ISlide slide in pres.Slides)
        {
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.OleObjectFrame)
                {
                    Aspose.Slides.OleObjectFrame oleObject = shape as Aspose.Slides.OleObjectFrame;
                    System.Byte[] data = oleObject.EmbeddedData.EmbeddedFileData;
                    System.String extension = oleObject.EmbeddedData.EmbeddedFileExtension;
                    System.String filePath = System.IO.Path.Combine(outputDir, "EmbeddedFile_" + fileIndex + extension);
                    System.IO.FileStream fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                    fileStream.Write(data, 0, data.Length);
                    fileStream.Close();
                    fileIndex++;
                }
            }
        }

        // Save the presentation before exiting
        pres.Save(sourcePath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}