using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        var inputPath = "large.pptx";
        var outputCompressed = "output_compressed.swf";
        var outputUncompressed = "output_uncompressed.swf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Save with default compression (Compressed = true)
            var defaultOptions = new Aspose.Slides.Export.SwfOptions();
            presentation.Save(outputCompressed, Aspose.Slides.Export.SaveFormat.Swf, defaultOptions);

            // Save with compression disabled
            var uncompressedOptions = new Aspose.Slides.Export.SwfOptions();
            uncompressedOptions.Compressed = false;
            presentation.Save(outputUncompressed, Aspose.Slides.Export.SaveFormat.Swf, uncompressedOptions);

            // Compare file sizes
            var sizeCompressed = new FileInfo(outputCompressed).Length;
            var sizeUncompressed = new FileInfo(outputUncompressed).Length;

            Console.WriteLine($"Compressed SWF size: {sizeCompressed} bytes");
            Console.WriteLine($"Uncompressed SWF size: {sizeUncompressed} bytes");

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("The format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}