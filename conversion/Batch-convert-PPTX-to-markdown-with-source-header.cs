using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input folder (first argument or current directory)
        string inputFolder = args.Length > 0 && !String.IsNullOrEmpty(args[0]) ? args[0] : Directory.GetCurrentDirectory();

        // Create output folder for markdown files
        string outputFolder = Path.Combine(inputFolder, "MarkdownOutput");
        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        // Get all PPTX files in the input folder
        string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx");
        foreach (string pptxPath in pptxFiles)
        {
            try
            {
                // Verify the file exists
                if (!File.Exists(pptxPath))
                {
                    Console.WriteLine($"File not found: {pptxPath}");
                    continue;
                }

                // Prepare output markdown file path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(pptxPath);
                string markdownPath = Path.Combine(outputFolder, fileNameWithoutExt + ".md");

                // Load the presentation
                Presentation pres = new Presentation(pptxPath);

                // Configure markdown save options
                MarkdownSaveOptions mdOptions = new MarkdownSaveOptions
                {
                    ExportType = MarkdownExportType.Visual,
                    ShowSlideNumber = false,
                    SlideNumberFormat = "# Slide {0}"
                };

                // Save presentation as markdown
                pres.Save(markdownPath, SaveFormat.Md, mdOptions);
                pres.Dispose();

                // Prepend metadata header with source file name
                string header = $"# Source: {Path.GetFileName(pptxPath)}{Environment.NewLine}{Environment.NewLine}";
                string originalContent = File.ReadAllText(markdownPath);
                File.WriteAllText(markdownPath, header + originalContent);
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine($"Format not supported for file: {pptxPath}");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine($"Error processing file {pptxPath}: {ex.Message}");
            }
        }
    }
}