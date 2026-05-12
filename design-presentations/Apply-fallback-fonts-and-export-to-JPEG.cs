using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputDir;
        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
        {
            inputDir = args[0];
        }
        else
        {
            inputDir = Directory.GetCurrentDirectory();
        }

        if (!Directory.Exists(inputDir))
        {
            Console.WriteLine("Input directory does not exist: " + inputDir);
            return;
        }

        // Load external fonts if a 'fonts' subfolder exists
        string fontsPath = Path.Combine(inputDir, "fonts");
        if (Directory.Exists(fontsPath))
        {
            string[] fontFolders = new string[] { fontsPath };
            Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);
        }

        string[] pptxFiles = Directory.GetFiles(inputDir, "*.pptx");
        foreach (string filePath in pptxFiles)
        {
            try
            {
                using (Presentation pres = new Presentation(filePath))
                {
                    // TODO: Apply font fallback rules using pres.FontsManager.FontFallBackRulesCollection

                    string processedDir = Path.Combine(inputDir, "Processed");
                    if (!Directory.Exists(processedDir))
                    {
                        Directory.CreateDirectory(processedDir);
                    }

                    string outputPath = Path.Combine(processedDir, Path.GetFileName(filePath));
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("File format not supported: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file " + filePath + ": " + ex.Message);
            }
        }

        // Clear font cache after processing
        Aspose.Slides.FontsLoader.ClearCache();
    }
}