using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string uncompressedPath = "uncompressed.pptx";
        string compressedPath = "compressed.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Save without compressing embedded fonts
            Aspose.Slides.Presentation presentationUncompressed = new Aspose.Slides.Presentation(inputPath);
            presentationUncompressed.Save(uncompressedPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentationUncompressed.Dispose();
        }
        catch (Exception ex)
        {
            // Handle format not supported or other errors
            Console.WriteLine("Error during uncompressed save: " + ex.Message);
            return;
        }

        try
        {
            // Embedded font compression (uses provided rule)
            System.String __inputPath__ = inputPath;
            System.String __outputPath__ = compressedPath;
            Aspose.Slides.Presentation __presentation__ = new Aspose.Slides.Presentation(__inputPath__);
            Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(__presentation__);
            __presentation__.Save(__outputPath__, Aspose.Slides.Export.SaveFormat.Pptx);
            __presentation__.Dispose();
        }
        catch (Exception ex)
        {
            // Handle format not supported or other errors
            Console.WriteLine("Error during compressed save: " + ex.Message);
            return;
        }

        // Compare file sizes
        System.IO.FileInfo fileInfoUncompressed = new System.IO.FileInfo(uncompressedPath);
        System.IO.FileInfo fileInfoCompressed = new System.IO.FileInfo(compressedPath);
        Console.WriteLine("Uncompressed size: " + fileInfoUncompressed.Length + " bytes");
        Console.WriteLine("Compressed size: " + fileInfoCompressed.Length + " bytes");
    }
}