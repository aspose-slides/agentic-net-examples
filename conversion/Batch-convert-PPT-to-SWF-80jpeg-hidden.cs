using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input directory from arguments or use current directory
        string inputDirectory;
        if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
        {
            inputDirectory = args[0];
        }
        else
        {
            inputDirectory = Environment.CurrentDirectory;
        }

        // Collect PPT and PPTX files
        string[] pptFiles = Directory.GetFiles(inputDirectory, "*.ppt");
        string[] pptxFiles = Directory.GetFiles(inputDirectory, "*.pptx");
        string[] allFiles = new string[pptFiles.Length + pptxFiles.Length];
        pptFiles.CopyTo(allFiles, 0);
        pptxFiles.CopyTo(allFiles, pptFiles.Length);

        foreach (string filePath in allFiles)
        {
            // Verify file existence
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                continue;
            }

            try
            {
                // Load presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))
                {
                    // Configure SWF options
                    Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
                    swfOptions.JpegQuality = 80;
                    swfOptions.ShowHiddenSlides = true;

                    // Prepare output path
                    string outputFileName = Path.GetFileNameWithoutExtension(filePath) + ".swf";
                    string outputPath = Path.Combine(inputDirectory, outputFileName);

                    // Save as SWF with options
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine($"Format not supported for file: {filePath}");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
            }
        }
    }
}