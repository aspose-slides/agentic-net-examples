using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Directory to store extracted files
            string outputDir = "ExtractedFiles";

            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                int fileIndex = 0;

                // Iterate through all slides and shapes
                foreach (ISlide slide in pres.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        // Check if the shape is an OLE object
                        if (shape is OleObjectFrame oleObject)
                        {
                            // Get embedded file data and its original extension
                            byte[] embeddedData = oleObject.EmbeddedData.EmbeddedFileData;
                            string fileExtension = oleObject.EmbeddedData.EmbeddedFileExtension;

                            // Build output file path
                            string outputFile = Path.Combine(outputDir, $"embedded_{fileIndex}{fileExtension}");

                            // Write the embedded file to disk
                            using (FileStream fileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                            {
                                fileStream.Write(embeddedData, 0, embeddedData.Length);
                            }

                            fileIndex++;
                        }
                    }
                }

                // Save the presentation before exiting
                string savedPath = "output.pptx";
                pres.Save(savedPath, SaveFormat.Pptx);
            }

            Console.WriteLine("All embedded files have been extracted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}