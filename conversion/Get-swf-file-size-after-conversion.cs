using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfConversionApp
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

            try
            {
                long swfSize = ConvertToSwfAndGetSize(inputPath, outputPath);
                Console.WriteLine("SWF file size: " + swfSize + " bytes");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static long ConvertToSwfAndGetSize(string inputPath, string outputPath)
        {
            // Load presentation
            Presentation presentation = new Presentation(inputPath);
            // Set SWF options if needed
            SwfOptions swfOptions = new SwfOptions();
            // Save as SWF
            presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
            // Ensure presentation is saved before getting file size
            presentation.Dispose();

            // Get file size
            FileInfo fileInfo = new FileInfo(outputPath);
            return fileInfo.Length;
        }
    }
}