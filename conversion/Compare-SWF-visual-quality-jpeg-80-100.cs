using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation path
        string inputPath = "input.pptx";
        // Output SWF files with different JPEG quality settings
        string outputSwfQuality80 = "output_quality80.swf";
        string outputSwfQuality100 = "output_quality100.swf";

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Save with JPEG quality 80
                SwfOptions swfOptions80 = new SwfOptions();
                swfOptions80.JpegQuality = 80;
                presentation.Save(outputSwfQuality80, SaveFormat.Swf, swfOptions80);

                // Save with JPEG quality 100
                SwfOptions swfOptions100 = new SwfOptions();
                swfOptions100.JpegQuality = 100;
                presentation.Save(outputSwfQuality100, SaveFormat.Swf, swfOptions100);
            }

            // Compare file sizes as a simple proxy for visual quality
            FileInfo fileInfo80 = new FileInfo(outputSwfQuality80);
            FileInfo fileInfo100 = new FileInfo(outputSwfQuality100);
            long size80 = fileInfo80.Length;
            long size100 = fileInfo100.Length;

            Console.WriteLine("SWF size with JPEG quality 80: " + size80 + " bytes");
            Console.WriteLine("SWF size with JPEG quality 100: " + size100 + " bytes");

            if (size80 < size100)
            {
                Console.WriteLine("Higher JPEG quality results in larger file size, indicating higher visual quality.");
            }
            else if (size80 > size100)
            {
                Console.WriteLine("Unexpected: lower JPEG quality produced larger file.");
            }
            else
            {
                Console.WriteLine("File sizes are equal.");
            }
        }
        catch (Exception ex)
        {
            // Handle format not supported or other errors
            // Format not supported.
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}