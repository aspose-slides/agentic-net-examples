using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input PPTX file path and output directory are taken from command line arguments
        string inputPath;
        string outputDir;
        if (args.Length >= 2)
        {
            inputPath = args[0];
            outputDir = args[1];
        }
        else
        {
            Console.WriteLine("Usage: program <input.pptx> <outputDirectory>");
            return;
        }

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Ensure the output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
        try
        {
            int fileIndex = 0;
            // Iterate through all slides and shapes to find OLE object frames
            foreach (Aspose.Slides.ISlide slide in pres.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.OleObjectFrame)
                    {
                        Aspose.Slides.OleObjectFrame oleFrame = shape as Aspose.Slides.OleObjectFrame;
                        // Extract embedded file data and its extension
                        byte[] data = oleFrame.EmbeddedData.EmbeddedFileData;
                        string extension = oleFrame.EmbeddedData.EmbeddedFileExtension;
                        // Build output file path
                        string outPath = Path.Combine(outputDir, "embedded_" + fileIndex + extension);
                        // Write the extracted file to disk
                        using (FileStream fs = new FileStream(outPath, FileMode.Create, FileAccess.Write, FileShare.Read))
                        {
                            fs.Write(data, 0, data.Length);
                        }
                        fileIndex++;
                    }
                }
            }
        }
        finally
        {
            // Save the presentation before exiting (no modifications made)
            pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}