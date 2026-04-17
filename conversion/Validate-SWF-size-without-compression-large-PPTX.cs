using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        var inputPath = "large_presentation.pptx";
        var outputCompressedPath = "output_compressed.swf";
        var outputUncompressedPath = "output_uncompressed.swf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        try
        {
            // Load the presentation
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Save with compression (default)
            var swfOptions = new Aspose.Slides.Export.SwfOptions();
            swfOptions.Compressed = true;
            presentation.Save(outputCompressedPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

            // Save without compression
            swfOptions.Compressed = false;
            presentation.Save(outputUncompressedPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

            // Get file sizes
            var compressedInfo = new FileInfo(outputCompressedPath);
            var uncompressedInfo = new FileInfo(outputUncompressedPath);

            Console.WriteLine($"Compressed SWF size: {compressedInfo.Length} bytes");
            Console.WriteLine($"Uncompressed SWF size: {uncompressedInfo.Length} bytes");

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            // Comment: format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., I/O errors)
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}