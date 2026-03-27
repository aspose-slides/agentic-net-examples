using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace OleObjectExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "input.pptx";
            // Output directory for extracted OLE objects
            string outputDir = "ExtractedOleObjects";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load presentation
            Presentation presentation = new Presentation(inputPath);

            // Counter for naming extracted files
            int fileIndex = 0;

            // Iterate through slides and shapes to find OLE object frames
            foreach (ISlide slide in presentation.Slides)
            {
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is OleObjectFrame)
                    {
                        OleObjectFrame oleFrame = shape as OleObjectFrame;
                        byte[] embeddedData = oleFrame.EmbeddedData.EmbeddedFileData;
                        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
                        string outputPath = Path.Combine(outputDir, "oleObject_" + fileIndex + fileExtension);

                        using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.Read))
                        {
                            fs.Write(embeddedData, 0, embeddedData.Length);
                        }

                        fileIndex++;
                    }
                }
            }

            // Save presentation (optional - here we save a copy)
            string savedPath = "output.pptx";
            presentation.Save(savedPath, SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();

            Console.WriteLine("Extraction completed. Files saved to: " + outputDir);
        }
    }
}