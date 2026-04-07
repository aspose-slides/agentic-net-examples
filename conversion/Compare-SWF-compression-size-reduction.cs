using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputCompressed = "output_compressed.swf";
        string outputUncompressed = "output_uncompressed.swf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Save with compression (default true)
            Aspose.Slides.Export.SwfOptions optionsCompressed = new Aspose.Slides.Export.SwfOptions();
            optionsCompressed.Compressed = true;
            presentation.Save(outputCompressed, Aspose.Slides.Export.SaveFormat.Swf, optionsCompressed);

            // Save without compression
            Aspose.Slides.Export.SwfOptions optionsUncompressed = new Aspose.Slides.Export.SwfOptions();
            optionsUncompressed.Compressed = false;
            presentation.Save(outputUncompressed, Aspose.Slides.Export.SaveFormat.Swf, optionsUncompressed);

            // Dispose presentation
            presentation.Dispose();

            // Compare file sizes
            FileInfo infoCompressed = new FileInfo(outputCompressed);
            FileInfo infoUncompressed = new FileInfo(outputUncompressed);

            Console.WriteLine($"Compressed file size: {infoCompressed.Length} bytes");
            Console.WriteLine($"Uncompressed file size: {infoUncompressed.Length} bytes");

            if (infoCompressed.Length < infoUncompressed.Length)
            {
                Console.WriteLine("Compressed file is smaller.");
            }
            else if (infoCompressed.Length > infoUncompressed.Length)
            {
                Console.WriteLine("Uncompressed file is smaller (unexpected).");
            }
            else
            {
                Console.WriteLine("Both files have the same size.");
            }
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