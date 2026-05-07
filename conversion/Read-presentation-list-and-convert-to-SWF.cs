using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the text file containing presentation paths
        string listFilePath = "presentations.txt";
        if (!File.Exists(listFilePath))
        {
            Console.WriteLine("List file not found: " + listFilePath);
            return;
        }

        string[] lines = File.ReadAllLines(listFilePath);
        foreach (string line in lines)
        {
            string inputPath = line.Trim();
            if (inputPath.Length == 0)
                continue;

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Presentation file not found: " + inputPath);
                continue;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
                    // Set any desired options here, e.g., swfOptions.Compressed = true;

                    string outputDirectory = Path.GetDirectoryName(inputPath);
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".swf";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
                    Console.WriteLine("Converted to SWF: " + outputPath);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("Format not supported for file: " + inputPath);
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("Error processing file " + inputPath + ": " + ex.Message);
            }
        }
    }
}