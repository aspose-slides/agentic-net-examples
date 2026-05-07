using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input directory containing PPT files
        string inputDir = "InputPpt";
        // Root output directory for XPS files
        string outputRootDir = "OutputXps";

        if (!Directory.Exists(inputDir))
        {
            Console.WriteLine("Input directory does not exist.");
            return;
        }

        if (!Directory.Exists(outputRootDir))
        {
            Directory.CreateDirectory(outputRootDir);
        }

        string[] pptFiles = Directory.GetFiles(inputDir, "*.ppt*");

        foreach (string pptPath in pptFiles)
        {
            try
            {
                if (!File.Exists(pptPath))
                {
                    Console.WriteLine("File not found: " + pptPath);
                    continue;
                }

                DateTime creationDate = File.GetCreationTime(pptPath);
                string dateFolder = creationDate.ToString("yyyyMMdd");
                string outputDir = Path.Combine(outputRootDir, dateFolder);

                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(pptPath);
                string xpsPath = Path.Combine(outputDir, fileNameWithoutExt + ".xps");

                using (Presentation pres = new Presentation(pptPath))
                {
                    // Save presentation to XPS format
                    pres.Save(xpsPath, SaveFormat.Xps);
                }

                Console.WriteLine("Converted: " + pptPath + " -> " + xpsPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("Format not supported for file: " + pptPath);
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., web service errors)
                Console.WriteLine("Error processing file " + pptPath + ": " + ex.Message);
            }
        }
    }
}