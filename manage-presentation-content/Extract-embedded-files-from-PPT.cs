using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractEmbeddedFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path (first argument)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            // Output directory for extracted files (second argument)
            string outputDir = args.Length > 1 ? args[1] : "ExtractedFiles";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure the output directory exists
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                int fileIndex = 0;

                // Iterate through all slides
                foreach (ISlide slide in pres.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (IShape shape in slide.Shapes)
                    {
                        // Check if the shape is an OLE object frame
                        if (shape is OleObjectFrame)
                        {
                            OleObjectFrame oleFrame = shape as OleObjectFrame;
                            // Retrieve embedded file data and extension
                            byte[] data = oleFrame.EmbeddedData.EmbeddedFileData;
                            string extension = oleFrame.EmbeddedData.EmbeddedFileExtension;
                            // Build output file path
                            string outFile = Path.Combine(outputDir, "extracted_" + fileIndex + extension);
                            // Write the embedded file to disk
                            using (FileStream fs = new FileStream(outFile, FileMode.Create, FileAccess.Write, FileShare.Read))
                            {
                                fs.Write(data, 0, data.Length);
                            }
                            fileIndex++;
                        }
                    }
                }

                // Save the presentation (no modifications, but required by rule)
                string savedPath = Path.Combine(outputDir, "output.pptx");
                pres.Save(savedPath, SaveFormat.Pptx);
            }
        }
    }
}