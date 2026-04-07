using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output directories
            string inputFolder = Path.Combine(Environment.CurrentDirectory, "Input");
            string outputFolder = Path.Combine(Environment.CurrentDirectory, "Output");
            string tiffFolder = Path.Combine(outputFolder, "tiff");
            string mp4Folder = Path.Combine(outputFolder, "mp4");

            // Ensure output directories exist
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);
            if (!Directory.Exists(tiffFolder))
                Directory.CreateDirectory(tiffFolder);
            if (!Directory.Exists(mp4Folder))
                Directory.CreateDirectory(mp4Folder);

            // Process each presentation file in the input folder
            if (Directory.Exists(inputFolder))
            {
                string[] files = Directory.GetFiles(inputFolder);
                foreach (string filePath in files)
                {
                    // Check if the file exists
                    if (!File.Exists(filePath))
                        continue;

                    // Load the presentation
                    Presentation pres = null;
                    try
                    {
                        pres = new Presentation(filePath);
                    }
                    catch (Exception ex)
                    {
                        // Handle loading exceptions (e.g., unsupported format)
                        Console.WriteLine("Failed to load presentation: " + ex.Message);
                        continue;
                    }

                    // Convert to TIFF
                    try
                    {
                        string tiffFileName = Path.GetFileNameWithoutExtension(filePath) + ".tiff";
                        string tiffOutputPath = Path.Combine(tiffFolder, tiffFileName);
                        pres.Save(tiffOutputPath, SaveFormat.Tiff);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("TIFF conversion failed: " + ex.Message);
                    }

                    // Convert to MP4 - not supported in current Aspose.Slides version
                    // The following code is intentionally omitted because MP4 format is not available.
                    // If support is added in the future, wrap the call in a try-catch for NotSupportedException.

                    // Save presentation before exiting (already saved above)
                    pres.Dispose();
                }
            }
            else
            {
                Console.WriteLine("Input folder does not exist: " + inputFolder);
            }
        }
    }
}