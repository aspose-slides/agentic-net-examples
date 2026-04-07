using System;
using System.Diagnostics;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation path (can be passed as first argument)
        string inputPath = args.Length > 0 ? args[0] : "largePresentation.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Output file paths for compressed and uncompressed SWF
        string outputCompressed = "output_compressed.swf";
        string outputUncompressed = "output_uncompressed.swf";

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // -------------------- Compressed SWF --------------------
            Aspose.Slides.Export.SwfOptions compressedOptions = new Aspose.Slides.Export.SwfOptions();
            compressedOptions.Compressed = true; // Ensure compression is enabled

            Stopwatch swCompressed = Stopwatch.StartNew();
            presentation.Save(outputCompressed, Aspose.Slides.Export.SaveFormat.Swf, compressedOptions);
            swCompressed.Stop();

            // -------------------- Uncompressed SWF --------------------
            Aspose.Slides.Export.SwfOptions uncompressedOptions = new Aspose.Slides.Export.SwfOptions();
            uncompressedOptions.Compressed = false; // Disable compression

            Stopwatch swUncompressed = Stopwatch.StartNew();
            presentation.Save(outputUncompressed, Aspose.Slides.Export.SaveFormat.Swf, uncompressedOptions);
            swUncompressed.Stop();

            // Output timing results
            Console.WriteLine("Compressed SWF generation time: " + swCompressed.Elapsed);
            Console.WriteLine("Uncompressed SWF generation time: " + swUncompressed.Elapsed);

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The requested format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}