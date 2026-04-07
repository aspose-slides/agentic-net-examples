using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace OdpToSwfConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine the directory to process
            string inputDirectory;
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                inputDirectory = args[0];
            }
            else
            {
                inputDirectory = Directory.GetCurrentDirectory();
            }

            // Verify that the directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("The specified directory does not exist: " + inputDirectory);
                return;
            }

            // Get all ODP files in the directory
            string[] odpFiles = Directory.GetFiles(inputDirectory, "*.odp", SearchOption.TopDirectoryOnly);

            foreach (string odpFilePath in odpFiles)
            {
                // Ensure the file exists before processing
                if (!File.Exists(odpFilePath))
                {
                    Console.WriteLine("File not found: " + odpFilePath);
                    continue;
                }

                try
                {
                    // Load the presentation
                    using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(odpFilePath))
                    {
                        // Build output SWF file path
                        string directory = Path.GetDirectoryName(odpFilePath);
                        string filenameWithoutExt = Path.GetFileNameWithoutExtension(odpFilePath);
                        string swfOutputPath = Path.Combine(directory ?? String.Empty, filenameWithoutExt + ".swf");

                        // Save as SWF using default settings
                        presentation.Save(swfOutputPath, Aspose.Slides.Export.SaveFormat.Swf);
                    }

                    Console.WriteLine("Converted: " + odpFilePath);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    // Comment: format not supported
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., I/O errors)
                    Console.WriteLine("Error processing file " + odpFilePath + ": " + ex.Message);
                }
            }
        }
    }
}