using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchExportHtml5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output directories relative to the current working directory
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "InputPresentations");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "OutputHtml5");

            // Verify that the input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.WriteLine($"Input directory does not exist: {inputDir}");
                return;
            }

            // Ensure the output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string[] presentationFiles;
            try
            {
                // Get all PPTX files in the input directory
                presentationFiles = Directory.GetFiles(inputDir, "*.pptx", SearchOption.TopDirectoryOnly);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine($"Could not find a part of the path: {inputDir}");
                return;
            }

            foreach (string presPath in presentationFiles)
            {
                // Verify each file exists before loading
                if (!File.Exists(presPath))
                {
                    Console.WriteLine($"File not found: {presPath}");
                    continue;
                }

                try
                {
                    // Load the presentation
                    using (Presentation presentation = new Presentation(presPath))
                    {
                        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(presPath);
                        string htmlOutputPath = Path.Combine(outputDir, fileNameWithoutExt + ".html");
                        string resourceOutputPath = Path.Combine(outputDir, fileNameWithoutExt + "_files");

                        // Ensure the folder for external resources exists
                        if (!Directory.Exists(resourceOutputPath))
                        {
                            Directory.CreateDirectory(resourceOutputPath);
                        }

                        // Configure HTML5 export options
                        Html5Options options = new Html5Options();
                        options.EmbedImages = false;               // Keep images as external files
                        options.OutputPath = resourceOutputPath;    // Store external resources here
                        options.SkipJavaScriptLinks = false;       // Preserve JavaScript links

                        // Export the presentation to HTML5
                        presentation.Save(htmlOutputPath, SaveFormat.Html5, options);

                        // Gzip all JavaScript files in the resource folder to reduce bandwidth
                        string[] jsFiles = Directory.GetFiles(resourceOutputPath, "*.js", SearchOption.AllDirectories);
                        foreach (string jsFile in jsFiles)
                        {
                            string gzFile = jsFile + ".gz";
                            using (FileStream originalFileStream = new FileStream(jsFile, FileMode.Open, FileAccess.Read))
                            using (FileStream compressedFileStream = new FileStream(gzFile, FileMode.Create))
                            using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                            {
                                originalFileStream.CopyTo(compressionStream);
                            }
                            // Optionally delete the original .js file after compression
                            // File.Delete(jsFile);
                        }

                        // Presentation is already saved; no further action required
                    }
                }
                catch (NotSupportedException)
                {
                    // Handle unsupported file formats gracefully
                    Console.WriteLine($"Format not supported for file: {presPath}");
                }
                catch (Exception ex)
                {
                    // General error handling (e.g., network issues, unexpected I/O errors)
                    Console.WriteLine($"Error processing file {presPath}: {ex.Message}");
                }
            }
        }
    }
}