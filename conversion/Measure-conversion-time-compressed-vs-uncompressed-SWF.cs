using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "large.pptx";
        string outputCompressed = "large_compressed.swf";
        string outputUncompressed = "large_uncompressed.swf";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            var presentation = new Presentation(inputPath);

            var swfOptionsCompressed = new SwfOptions();
            swfOptionsCompressed.Compressed = true;

            var swfOptionsUncompressed = new SwfOptions();
            swfOptionsUncompressed.Compressed = false;

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            presentation.Save(outputCompressed, SaveFormat.Swf, swfOptionsCompressed);
            stopwatch.Stop();
            var compressedTime = stopwatch.Elapsed;

            stopwatch.Reset();
            stopwatch.Start();
            presentation.Save(outputUncompressed, SaveFormat.Swf, swfOptionsUncompressed);
            stopwatch.Stop();
            var uncompressedTime = stopwatch.Elapsed;

            Console.WriteLine($"Compressed SWF conversion time: {compressedTime}");
            Console.WriteLine($"Uncompressed SWF conversion time: {uncompressedTime}");

            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}