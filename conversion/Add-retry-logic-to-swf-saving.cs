using System;
using System.IO;
using System.Threading;
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

            // Retry parameters
            int maxAttempts = 3;
            int attempt = 0;
            bool saved = false;

            while (attempt < maxAttempts && !saved)
            {
                try
                {
                    // Load presentation
                    using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                    {
                        // SWF conversion options (default)
                        Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

                        // Save as SWF
                        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
                    }

                    // If no exception, mark as saved
                    saved = true;
                    Console.WriteLine("Presentation saved successfully to: " + outputPath);
                }
                catch (IOException ioEx)
                {
                    // Transient file access error, retry after delay
                    attempt++;
                    Console.WriteLine("IO exception encountered (attempt " + attempt + "): " + ioEx.Message);
                    if (attempt < maxAttempts)
                    {
                        Thread.Sleep(1000); // wait 1 second before retry
                    }
                    else
                    {
                        Console.WriteLine("Maximum retry attempts reached. Conversion failed.");
                    }
                }
                catch (NotSupportedException nsEx)
                {
                    // Format not supported
                    Console.WriteLine("Format not supported: " + nsEx.Message);
                    break;
                }
                catch (Exception ex)
                {
                    // Other unexpected errors
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                    break;
                }
            }
        }
    }
}