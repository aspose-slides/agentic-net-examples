using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchExportToXps
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output directories can be passed as arguments or defaulted
            string inputDirectory = args.Length > 0 ? args[0] : "InputPpt";
            string outputBaseDirectory = args.Length > 1 ? args[1] : "OutputXps";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist: " + inputDirectory);
                return;
            }

            // Ensure base output directory exists
            if (!Directory.Exists(outputBaseDirectory))
            {
                Directory.CreateDirectory(outputBaseDirectory);
            }

            // Supported PowerPoint extensions
            string[] supportedExtensions = new string[] { ".ppt", ".pptx", ".odp", ".pptm", ".ppsx", ".ppsm", ".potx", ".potm", ".pps", ".pot", ".fodp" };

            // Process each file in the input directory
            string[] files = Directory.GetFiles(inputDirectory);
            foreach (string filePath in files)
            {
                // Skip files without supported extensions
                string extension = Path.GetExtension(filePath);
                bool isSupported = false;
                foreach (string ext in supportedExtensions)
                {
                    if (string.Equals(ext, extension, StringComparison.OrdinalIgnoreCase))
                    {
                        isSupported = true;
                        break;
                    }
                }
                if (!isSupported)
                {
                    continue;
                }

                // Verify the file exists before loading
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found: " + filePath);
                    continue;
                }

                // Determine creation date folder
                DateTime creationTime = File.GetCreationTime(filePath);
                string dateFolder = creationTime.ToString("yyyyMMdd");
                string outputDirectory = Path.Combine(outputBaseDirectory, dateFolder);
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                // Build output XPS file path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".xps");

                try
                {
                    // Load presentation and save as XPS
                    using (Presentation pres = new Presentation(filePath))
                    {
                        // Save without additional XPS options (convert-without-xps-options rule)
                        pres.Save(outputPath, SaveFormat.Xps);
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    // Comment: The source file format is not supported for conversion to XPS.
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing file '" + filePath + "': " + ex.Message);
                }
            }
        }
    }
}