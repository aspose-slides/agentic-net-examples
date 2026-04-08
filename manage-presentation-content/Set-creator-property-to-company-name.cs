using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchUpdateCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input folder path (first argument) or default folder
            string inputFolder = args.Length > 0 ? args[0] : "Presentations";
            // Company name to set as Creator (second argument) or default value
            string companyName = args.Length > 1 ? args[1] : "MyCompany";

            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine("Input folder does not exist: " + inputFolder);
                return;
            }

            // Get all supported presentation files in the folder
            string[] presentationFiles = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string filePath in presentationFiles)
            {
                // Process only known presentation extensions
                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                if (extension != ".pptx" && extension != ".ppt" && extension != ".odp")
                {
                    continue;
                }

                // Verify the file exists before processing
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found: " + filePath);
                    continue;
                }

                try
                {
                    // Load the presentation
                    string inputPath = filePath;
                    string outputPath = filePath; // Overwrite the same file
                    Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                    Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;
                    // Update the Creator (Author) property
                    documentProperties.Author = companyName;
                    // Save the presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    presentation.Dispose();

                    Console.WriteLine("Updated Creator for: " + Path.GetFileName(filePath));
                }
                catch (Exception ex)
                {
                    // Handle unsupported format or other errors
                    Console.WriteLine("Failed to process " + Path.GetFileName(filePath) + ": " + ex.Message);
                    // Format not supported comment
                    // Note: If the exception is due to unsupported format, the message will indicate it.
                }
            }
        }
    }
}