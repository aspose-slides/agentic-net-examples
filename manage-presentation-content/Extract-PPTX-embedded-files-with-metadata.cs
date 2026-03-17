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
            // Input PPTX file path
            string inputPath = "input.pptx";
            // Output directory for extracted files
            string outputDir = "ExtractedFiles";

            try
            {
                // Ensure output directory exists
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    int fileIndex = 0;

                    // Iterate through all slides
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            // Check if the shape is an OLE object
                            if (shape is Aspose.Slides.OleObjectFrame)
                            {
                                Aspose.Slides.OleObjectFrame oleObject = shape as Aspose.Slides.OleObjectFrame;

                                // Get embedded file data and extension
                                byte[] embeddedData = oleObject.EmbeddedData.EmbeddedFileData;
                                string fileExtension = oleObject.EmbeddedData.EmbeddedFileExtension;

                                // Optional: use the OLE object's label as part of the file name
                                string fileLabel = oleObject.EmbeddedFileLabel;

                                // Build output file path preserving original type
                                string outputFilePath = Path.Combine(outputDir,
                                    $"embedded_{fileIndex}_{fileLabel}{fileExtension}");

                                // Write the extracted file to disk
                                using (FileStream fileStream = new FileStream(outputFilePath,
                                    FileMode.Create, FileAccess.Write, FileShare.Read))
                                {
                                    fileStream.Write(embeddedData, 0, embeddedData.Length);
                                }

                                fileIndex++;
                            }
                        }
                    }

                    // Save the presentation before exiting (even if unchanged)
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during extraction
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}