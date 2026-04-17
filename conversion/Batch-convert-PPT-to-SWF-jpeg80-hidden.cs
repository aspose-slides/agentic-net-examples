using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputDirectory = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
        if (!Directory.Exists(inputDirectory))
        {
            Console.WriteLine("Input directory does not exist.");
            return;
        }

        string[] files = Directory.GetFiles(inputDirectory, "*.ppt*");
        foreach (string filePath in files)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found: " + filePath);
                    continue;
                }

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))
                {
                    Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
                    swfOptions.JpegQuality = 80;
                    swfOptions.ShowHiddenSlides = true;

                    string outputFileName = Path.GetFileNameWithoutExtension(filePath) + ".swf";
                    string outputPath = Path.Combine(inputDirectory, outputFileName);

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("Format not supported for file: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file " + filePath + ": " + ex.Message);
            }
        }
    }
}