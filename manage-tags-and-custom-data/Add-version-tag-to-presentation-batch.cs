using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchVersionTagger
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine the directory to process
            string targetDirectory;
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                targetDirectory = args[0];
            }
            else
            {
                targetDirectory = Directory.GetCurrentDirectory();
            }

            // Verify directory exists
            if (!Directory.Exists(targetDirectory))
            {
                Console.WriteLine("Directory does not exist: " + targetDirectory);
                return;
            }

            // Get all supported presentation files
            string[] supportedExtensions = new string[] { ".pptx", ".ppt", ".odp", ".pptm", ".potx", ".potm", ".ppsx", ".pps" };
            string[] presentationFiles = Directory.GetFiles(targetDirectory);
            foreach (string filePath in presentationFiles)
            {
                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                if (Array.IndexOf(supportedExtensions, extension) < 0)
                {
                    // Skip unsupported file types
                    continue;
                }

                // Check if file exists (redundant after GetFiles, but per requirement)
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found: " + filePath);
                    continue;
                }

                try
                {
                    // Load the presentation
                    Presentation presentation = new Presentation(filePath);

                    // Add version tag to the first slide
                    ISlide firstSlide = presentation.Slides[0];
                    IAutoShape versionShape = firstSlide.Shapes.AddAutoShape(
                        ShapeType.Rectangle, 10, 10, 400, 30);
                    versionShape.TextFrame.Text = "Version: 1.0";

                    // Determine appropriate SaveFormat based on extension
                    SaveFormat saveFormat;
                    switch (extension)
                    {
                        case ".pptx":
                        case ".pptm":
                        case ".potx":
                        case ".ppsx":
                            saveFormat = SaveFormat.Pptx;
                            break;
                        case ".ppt":
                        case ".pot":
                        case ".pps":
                            saveFormat = SaveFormat.Ppt;
                            break;
                        case ".odp":
                            saveFormat = SaveFormat.Odp;
                            break;
                        default:
                            // Default to PPTX if unknown
                            saveFormat = SaveFormat.Pptx;
                            break;
                    }

                    // Save the modified presentation (overwrite original)
                    presentation.Save(filePath, saveFormat);
                    presentation.Dispose();

                    Console.WriteLine("Processed: " + Path.GetFileName(filePath));
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine("Format not supported for file: " + Path.GetFileName(filePath));
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine("Error processing file " + Path.GetFileName(filePath) + ": " + ex.Message);
                }
            }

            Console.WriteLine("Batch processing completed.");
        }
    }
}