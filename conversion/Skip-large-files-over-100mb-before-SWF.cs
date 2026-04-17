using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchSwfConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Process each file path provided as a command‑line argument
            foreach (string inputPath in args)
            {
                // Verify that the file exists
                if (!File.Exists(inputPath))
                {
                    continue;
                }

                // Skip files larger than 100 MB
                FileInfo fileInfo = new FileInfo(inputPath);
                if (fileInfo.Length > 100L * 1024 * 1024)
                {
                    continue;
                }

                try
                {
                    // Load the presentation
                    using (Presentation presentation = new Presentation(inputPath))
                    {
                        // Prepare SWF conversion options
                        SwfOptions swfOptions = new SwfOptions();

                        // Determine output file path (same folder, .swf extension)
                        string outputDirectory = Path.GetDirectoryName(inputPath) ?? string.Empty;
                        string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".swf";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Convert to SWF format
                        presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported – skip this file
                }
                catch (Exception)
                {
                    // Handle other unexpected errors (e.g., I/O issues)
                }
            }
        }
    }
}