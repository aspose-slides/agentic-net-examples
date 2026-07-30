// -----------------------------------------------------------------------------
// Example: Export PPTX to HTML zip archive using C#
//
// Description:
// Demonstrates how to export a PPTX presentation to an HTML file along with
// its associated resources, and then package both the HTML file and the
// resources folder into a ZIP archive using Aspose.Slides for .NET. The example
// shows loading a presentation, configuring HTML export options (including
// PNG slide images), saving the HTML output, locating the generated resources
// folder, and creating a ZIP archive that preserves the folder structure.
// This pattern can be used in console applications or automated workflows.
//
// Keywords:
// C#, Aspose.Slides, PPTX, HTML export, ZIP archive, Presentation conversion,
// PowerPoint, Slide images, Console application, .NET
//
// Use Cases:
// - Convert PowerPoint presentations to web‑ready HTML with embedded assets.
// - Package exported HTML and resources into a single distributable ZIP file.
// - Automate batch conversion of PPTX files for web publishing or archiving.
// - Integrate presentation export functionality into .NET tools or services.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.IO.Compression;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPresentationToHtmlZip
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output paths
            string inputPath = "input.pptx";
            string outputHtmlPath = "output.html";
            string outputZipPath = "output.zip";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure HTML export options
                    HtmlOptions htmlOptions = new HtmlOptions();
                    // Set slide images to PNG format using SlideImageFormat.Bitmap
                    htmlOptions.SlideImageFormat = SlideImageFormat.Bitmap(1f, ImageFormat.Png);

                    // Save presentation as HTML (creates HTML file and a resources folder)
                    presentation.Save(outputHtmlPath, SaveFormat.Html, htmlOptions);
                }

                // Determine the resources folder created by the HTML export
                string resourcesFolder = Path.Combine(
                    Path.GetDirectoryName(outputHtmlPath),
                    Path.GetFileNameWithoutExtension(outputHtmlPath) + "_files");

                // Create ZIP archive containing the HTML file and its resources
                using (FileStream zipStream = new FileStream(outputZipPath, FileMode.Create))
                {
                    using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
                    {
                        // Add the main HTML file
                        archive.CreateEntryFromFile(outputHtmlPath, Path.GetFileName(outputHtmlPath));

                        // Add all resource files if the folder exists
                        if (Directory.Exists(resourcesFolder))
                        {
                            string[] resourceFiles = Directory.GetFiles(resourcesFolder, "*", SearchOption.AllDirectories);
                            foreach (string filePath in resourceFiles)
                            {
                                // Preserve folder structure inside the ZIP
                                string relativePath = Path.GetRelativePath(resourcesFolder, filePath);
                                string entryName = Path.Combine(Path.GetFileName(resourcesFolder), relativePath).Replace('\\', '/');
                                archive.CreateEntryFromFile(filePath, entryName);
                            }
                        }
                    }
                }

                Console.WriteLine("Export completed successfully. ZIP archive created at: " + outputZipPath);
            }
            catch (PptxUnsupportedFormatException)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("The input file format is not supported (PPTX).");
            }
            catch (PptUnsupportedFormatException)
            {
                // Handle unsupported PPT format
                Console.WriteLine("The input file format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
