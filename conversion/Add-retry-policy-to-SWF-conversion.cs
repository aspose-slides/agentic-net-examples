using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.swf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Retry policy: up to three attempts for transient I/O errors
            const int maxAttempts = 3;
            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                try
                {
                    // Load presentation
                    using (Presentation pres = new Presentation(inputPath))
                    {
                        // Configure SWF options if needed
                        SwfOptions swfOptions = new SwfOptions();

                        // Save as SWF
                        pres.Save(outputPath, SaveFormat.Swf, swfOptions);
                    }

                    // Conversion succeeded, exit loop
                    Console.WriteLine("Conversion succeeded on attempt " + attempt);
                    break;
                }
                catch (IOException ioEx)
                {
                    // Transient I/O error handling
                    Console.WriteLine("I/O error on attempt " + attempt + ": " + ioEx.Message);
                    if (attempt == maxAttempts)
                    {
                        Console.WriteLine("Maximum retry attempts reached. Conversion failed.");
                    }
                }
                catch (NotSupportedException nsEx)
                {
                    // Format not supported
                    Console.WriteLine("Format not supported: " + nsEx.Message);
                    // No retry for this case
                    break;
                }
                catch (Exception ex)
                {
                    // Other unexpected errors
                    Console.WriteLine("Unexpected error: " + ex.Message);
                    break;
                }
            }
        }
    }
}