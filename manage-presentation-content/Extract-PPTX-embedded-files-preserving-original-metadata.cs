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

            // Ensure the output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            try
            {
                // Counter for naming extracted files
                int fileIndex = 0;

                // Iterate through all slides
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Check if the shape is an OLE object frame
                        if (shape is Aspose.Slides.OleObjectFrame)
                        {
                            Aspose.Slides.OleObjectFrame oleObject = shape as Aspose.Slides.OleObjectFrame;

                            // Get the embedded binary data
                            byte[] embeddedData = oleObject.EmbeddedData.EmbeddedFileData;
                            // Get the original file extension (including the dot)
                            string fileExtension = oleObject.EmbeddedData.EmbeddedFileExtension;
                            // Get the original file name label if available
                            string fileLabel = oleObject.EmbeddedFileLabel;
                            if (string.IsNullOrEmpty(fileLabel))
                            {
                                fileLabel = "embeddedFile";
                            }

                            // Build the output file path
                            string outputFilePath = Path.Combine(outputDir, $"{fileLabel}_{fileIndex}{fileExtension}");

                            // Write the embedded data to the file
                            FileStream fileStream = null;
                            try
                            {
                                fileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.Read);
                                fileStream.Write(embeddedData, 0, embeddedData.Length);
                                Console.WriteLine($"Extracted: {outputFilePath}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error writing file: " + ex.Message);
                            }
                            finally
                            {
                                if (fileStream != null)
                                {
                                    fileStream.Dispose();
                                }
                            }

                            fileIndex++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during extraction: " + ex.Message);
            }
            finally
            {
                // Save the presentation before exiting (if any modifications were made)
                try
                {
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }

                // Dispose the presentation object
                presentation.Dispose();
            }
        }
    }
}