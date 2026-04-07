using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        string compressedSwfPath = Path.Combine(Directory.GetCurrentDirectory(), "output_compressed.swf");
        string uncompressedSwfPath = Path.Combine(Directory.GetCurrentDirectory(), "output_uncompressed.swf");
        string tempPptxPath = Path.Combine(Directory.GetCurrentDirectory(), "temp_saved.pptx");

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Save the presentation (required before exit)
            presentation.Save(tempPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Save compressed SWF (default compression)
            Aspose.Slides.Export.SwfOptions swfOptionsCompressed = new Aspose.Slides.Export.SwfOptions();
            presentation.Save(compressedSwfPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptionsCompressed);

            // Save uncompressed SWF
            Aspose.Slides.Export.SwfOptions swfOptionsUncompressed = new Aspose.Slides.Export.SwfOptions();
            swfOptionsUncompressed.Compressed = false;
            presentation.Save(uncompressedSwfPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptionsUncompressed);

            // Dispose the presentation
            presentation.Dispose();

            long compressedSize = new FileInfo(compressedSwfPath).Length;
            long uncompressedSize = new FileInfo(uncompressedSwfPath).Length;
            Console.WriteLine($"Compressed size: {compressedSize} bytes");
            Console.WriteLine($"Uncompressed size: {uncompressedSize} bytes");

            if (uncompressedSize >= (long)(compressedSize * 1.2))
            {
                Console.WriteLine("Uncompressed file is at least 20% larger than the compressed version.");
            }
            else
            {
                Console.WriteLine("Uncompressed file is not sufficiently larger.");
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}