using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input folder
        string inputFolder;
        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
        {
            inputFolder = args[0];
        }
        else
        {
            inputFolder = Path.Combine(Environment.CurrentDirectory, "Input");
        }

        // Determine output folder
        string outputFolder;
        if (args.Length > 1 && !string.IsNullOrEmpty(args[1]))
        {
            outputFolder = args[1];
        }
        else
        {
            outputFolder = Path.Combine(Environment.CurrentDirectory, "Output");
        }

        // Verify input folder exists
        if (!Directory.Exists(inputFolder))
        {
            Console.WriteLine("Input folder does not exist: " + inputFolder);
            return;
        }

        // Ensure output folder exists
        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        // Get all PPTX files recursively
        string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx", SearchOption.AllDirectories);
        foreach (string pptxPath in pptxFiles)
        {
            try
            {
                // Compute relative path to preserve hierarchy
                string relativePath = Path.GetRelativePath(inputFolder, pptxPath);
                string relativeDir = Path.GetDirectoryName(relativePath);
                string targetDir = Path.Combine(outputFolder, relativeDir ?? string.Empty);
                if (!Directory.Exists(targetDir))
                {
                    Directory.CreateDirectory(targetDir);
                }

                // Define output HTML5 file path
                string outputFileName = Path.GetFileNameWithoutExtension(pptxPath) + ".html";
                string outputPath = Path.Combine(targetDir, outputFileName);

                // Load presentation and save as HTML5
                using (Presentation pres = new Presentation(pptxPath))
                {
                    Html5Options options = new Html5Options();
                    // Store external resources in the same directory as the HTML file
                    options.OutputPath = targetDir;
                    pres.Save(outputPath, SaveFormat.Html5, options);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error processing file: " + pptxPath);
                Console.WriteLine(ex.Message);
            }
        }
    }
}