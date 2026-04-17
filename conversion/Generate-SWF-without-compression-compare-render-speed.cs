using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output paths
            string outputCompressedPath = "output_compressed.swf";
            string outputUncompressedPath = "output_uncompressed.swf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Save with default (compressed) options
                Aspose.Slides.Export.SwfOptions compressedOptions = new Aspose.Slides.Export.SwfOptions();
                // Compressed is true by default; no need to set
                presentation.Save(outputCompressedPath, Aspose.Slides.Export.SaveFormat.Swf, compressedOptions);

                // Save with compression disabled
                Aspose.Slides.Export.SwfOptions uncompressedOptions = new Aspose.Slides.Export.SwfOptions();
                uncompressedOptions.Compressed = false;
                presentation.Save(outputUncompressedPath, Aspose.Slides.Export.SaveFormat.Swf, uncompressedOptions);

                // Dispose presentation
                presentation.Dispose();

                // Compare rendering speed (manual observation)
                // The uncompressed SWF file is typically larger but may render faster in some Flash players.
                Console.WriteLine("SWF files generated:");
                Console.WriteLine("Compressed: " + outputCompressedPath);
                Console.WriteLine("Uncompressed: " + outputUncompressedPath);
                Console.WriteLine("Please open both files in a Flash player to compare rendering speed.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}