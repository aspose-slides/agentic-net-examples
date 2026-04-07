using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.swf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        int maxAttempts = 3;
        int attempt = 0;
        bool success = false;

        while (attempt < maxAttempts && !success)
        {
            attempt++;
            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Configure SWF options
                    SwfOptions options = new SwfOptions();
                    options.Compressed = true; // example setting

                    // Save as SWF
                    pres.Save(outputPath, SaveFormat.Swf, options);
                }

                success = true;
                Console.WriteLine("Conversion succeeded.");
            }
            catch (IOException ioEx)
            {
                // Handle transient I/O errors and retry
                Console.WriteLine($"I/O error on attempt {attempt}: {ioEx.Message}");
                if (attempt >= maxAttempts)
                {
                    Console.WriteLine("Maximum retry attempts reached. Conversion failed.");
                }
            }
            catch (NotSupportedException nsEx)
            {
                // Format not supported
                Console.WriteLine($"Format not supported: {nsEx.Message}");
                break;
            }
            catch (Exception ex)
            {
                // Handle other unexpected errors
                Console.WriteLine($"Unexpected error: {ex.Message}");
                break;
            }
        }
    }
}