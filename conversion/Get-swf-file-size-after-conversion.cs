using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.swf";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            long swfSize = ConvertToSwfAndGetSize(inputPath, outputPath);
            Console.WriteLine("SWF file size: " + swfSize + " bytes");
        }

        static long ConvertToSwfAndGetSize(string inputPath, string outputPath)
        {
            // Load presentation
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Format not supported.
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return 0;
            }

            // Set SWF conversion options
            SwfOptions swfOptions = new SwfOptions();
            swfOptions.ViewerIncluded = false;

            try
            {
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving SWF: " + ex.Message);
                presentation.Dispose();
                return 0;
            }

            // Ensure presentation is saved before exit
            presentation.Dispose();

            // Get file size
            long fileSize = 0;
            try
            {
                FileInfo fileInfo = new FileInfo(outputPath);
                fileSize = fileInfo.Length;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting file size: " + ex.Message);
            }

            return fileSize;
        }
    }
}