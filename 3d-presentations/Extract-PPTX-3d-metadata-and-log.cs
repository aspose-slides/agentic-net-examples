using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Extract3DMetadata
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input file path
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Check if the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Access document properties
                    IDocumentProperties properties = presentation.DocumentProperties;

                    // Log author and creation date
                    Console.WriteLine("Author: " + properties.Author);
                    Console.WriteLine("Created Time (UTC): " + properties.CreatedTime.ToUniversalTime());

                    // Save the presentation before exiting (no changes made)
                    string outputPath = Path.Combine(
                        Path.GetDirectoryName(inputPath) ?? "",
                        Path.GetFileNameWithoutExtension(inputPath) + "_out.pptx");
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported for PPTX files
                Console.WriteLine("The file format is not supported (PPTX).");
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported for PPT files
                Console.WriteLine("The file format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}