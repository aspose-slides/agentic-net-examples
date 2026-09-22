// -----------------------------------------------------------------------------
// Example: Export PPTX to HTML with Resources and Package into ZIP
//
// Description:
// This console application loads a PowerPoint PPTX file using Aspose.Slides for .NET,
// exports it to an HTML file with PNG slide images, and then creates a ZIP archive
// containing the HTML file and its associated resources folder. It demonstrates
// handling file existence checks, configuring HtmlOptions, and using .NET's
// ZipFile class to package the output for distribution.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, HTML export, ZIP archive, slide images
//
// Use Cases:
// - Automating conversion of presentations to web-friendly HTML bundles.
// - Preparing presentation assets for deployment to static web servers.
// - Integrating PPTX to HTML conversion into CI/CD pipelines.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.IO.Compression;

namespace AsposeSlidesHtmlExport
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPptxPath = "input.pptx";
            // Output HTML file path
            string outputHtmlPath = "output.html";
            // Output ZIP file path
            string outputZipPath = "PresentationExport.zip";

            // Verify input file exists
            if (!File.Exists(inputPptxPath))
            {
                Console.WriteLine("Input file not found: " + inputPptxPath);
                return;
            }

            try
            {
                // Load presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPptxPath);

                // Configure HTML export options (default uses PNG for slide images)
                Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();

                // Save presentation as HTML
                presentation.Save(outputHtmlPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

                // Determine resources folder (Aspose creates a folder named <htmlFileName>_files)
                string resourcesFolder = Path.Combine(Path.GetDirectoryName(outputHtmlPath), Path.GetFileNameWithoutExtension(outputHtmlPath) + "_files");

                // Verify resources folder exists
                if (!Directory.Exists(resourcesFolder))
                {
                    Console.WriteLine("Resources folder not found: " + resourcesFolder);
                }

                // Create temporary directory to hold HTML and resources together for zipping
                string tempExportDir = Path.Combine(Path.GetTempPath(), "AsposeSlidesExport_" + Guid.NewGuid().ToString("N"));
                Directory.CreateDirectory(tempExportDir);

                // Copy HTML file
                string tempHtmlPath = Path.Combine(tempExportDir, Path.GetFileName(outputHtmlPath));
                File.Copy(outputHtmlPath, tempHtmlPath, true);

                // Copy resources folder
                if (Directory.Exists(resourcesFolder))
                {
                    string tempResourcesPath = Path.Combine(tempExportDir, Path.GetFileName(resourcesFolder));
                    CopyDirectory(resourcesFolder, tempResourcesPath);
                }

                // Create ZIP archive from temporary directory
                if (File.Exists(outputZipPath))
                {
                    File.Delete(outputZipPath);
                }
                System.IO.Compression.ZipFile.CreateFromDirectory(tempExportDir, outputZipPath, CompressionLevel.Optimal, false);

                // Clean up temporary directory
                Directory.Delete(tempExportDir, true);

                // Dispose presentation
                presentation.Dispose();

                Console.WriteLine("Export completed successfully.");
                Console.WriteLine("HTML file: " + outputHtmlPath);
                Console.WriteLine("Resources folder: " + resourcesFolder);
                Console.WriteLine("ZIP archive: " + outputZipPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during export: " + ex.Message);
            }
        }

        // Helper method to copy a directory recursively
        private static void CopyDirectory(string sourceDir, string destinationDir)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDir);
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException("Source directory does not exist: " + sourceDir);
            }

            DirectoryInfo[] subDirs = dir.GetDirectories();
            Directory.CreateDirectory(destinationDir);

            // Copy files
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath, true);
            }

            // Copy subdirectories
            foreach (DirectoryInfo subDir in subDirs)
            {
                string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                CopyDirectory(subDir.FullName, newDestinationDir);
            }
        }
    }
}
