using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input directory (current directory)
        string inputDir = Directory.GetCurrentDirectory();

        // Supported presentation extensions
        string[] supportedExtensions = new string[] { ".ppt", ".pptx", ".odp", ".pptm", ".ppsx", ".ppsm", ".potx", ".potm", ".pps", ".pot", ".fodp", ".xml" };

        // Get all files and filter supported ones
        string[] allFiles = Directory.GetFiles(inputDir);
        System.Collections.Generic.List<string> presentationFiles = new System.Collections.Generic.List<string>();
        foreach (string filePath in allFiles)
        {
            string ext = Path.GetExtension(filePath).ToLowerInvariant();
            foreach (string supExt in supportedExtensions)
            {
                if (ext == supExt)
                {
                    presentationFiles.Add(filePath);
                    break;
                }
            }
        }

        // Sort alphabetically
        presentationFiles.Sort();

        // Process each presentation
        foreach (string filePath in presentationFiles)
        {
            // Verify file existence
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found: " + filePath);
                continue;
            }

            try
            {
                // Load presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))
                {
                    // Output SWF path
                    string outputPath = Path.Combine(inputDir, Path.GetFileNameWithoutExtension(filePath) + ".swf");

                    // Save as SWF
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf);
                }

                Console.WriteLine("Converted to SWF: " + filePath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("Format not supported for file: " + filePath);
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error processing file: " + filePath);
                Console.WriteLine(ex.Message);
            }
        }
    }
}