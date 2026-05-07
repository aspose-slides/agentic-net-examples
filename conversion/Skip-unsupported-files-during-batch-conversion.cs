using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        if (args == null || args.Length == 0)
        {
            Console.WriteLine("Please provide file paths as arguments.");
            return;
        }

        foreach (string inputPath in args)
        {
            if (string.IsNullOrEmpty(inputPath))
            {
                continue;
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"File not found: {inputPath}");
                continue;
            }

            string extension = Path.GetExtension(inputPath).ToLowerInvariant();
            if (extension != ".pptx" && extension != ".odp")
            {
                Console.WriteLine($"Unsupported file type: {inputPath}");
                continue;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    string directory = Path.GetDirectoryName(inputPath);
                    string filenameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(directory ?? string.Empty, filenameWithoutExt + ".pdf");

                    pres.Save(outputPath, SaveFormat.Pdf);
                    Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                Console.WriteLine($"Skipped unsupported PPTX format: {inputPath}");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                Console.WriteLine($"Skipped unsupported PPT format: {inputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {inputPath}: {ex.Message}");
            }
        }
    }
}