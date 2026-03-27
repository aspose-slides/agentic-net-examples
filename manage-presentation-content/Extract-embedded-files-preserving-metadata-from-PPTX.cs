using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputDir = "ExtractedFiles";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
        try
        {
            int fileIndex = 0;
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.OleObjectFrame)
                    {
                        Aspose.Slides.OleObjectFrame ole = shape as Aspose.Slides.OleObjectFrame;
                        byte[] data = ole.EmbeddedData.EmbeddedFileData;
                        string extension = ole.EmbeddedData.EmbeddedFileExtension;
                        string outPath = Path.Combine(outputDir, $"embedded_{fileIndex}{extension}");
                        using (FileStream fs = new FileStream(outPath, FileMode.Create, FileAccess.Write, FileShare.Read))
                        {
                            fs.Write(data, 0, data.Length);
                        }
                        fileIndex++;
                    }
                }
            }

            // Save presentation (no modifications) to satisfy lifecycle requirement
            string tempSavePath = Path.Combine(outputDir, "temp_saved.pptx");
            presentation.Save(tempSavePath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        finally
        {
            presentation.Dispose();
        }
    }
}