using System;
using System.IO;
using System.Threading;
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

            // Create presentation object
            Presentation pres = new Presentation(inputPath);

            // Configure SWF options
            SwfOptions swfOptions = new SwfOptions();
            swfOptions.ViewerIncluded = true; // example setting

            // Retry mechanism for transient file access errors
            int maxRetries = 3;
            int attempt = 0;
            while (true)
            {
                try
                {
                    pres.Save(outputPath, SaveFormat.Swf, swfOptions);
                    break; // Success
                }
                catch (IOException ioEx)
                {
                    attempt++;
                    if (attempt >= maxRetries)
                    {
                        Console.WriteLine("Failed to save after multiple attempts: " + ioEx.Message);
                        break;
                    }
                    // Wait before retrying
                    Thread.Sleep(1000);
                }
                catch (NotSupportedException nsEx)
                {
                    // Format not supported
                    Console.WriteLine("The requested format is not supported: " + nsEx.Message);
                    break;
                }
                catch (Exception ex)
                {
                    // Other exceptions
                    Console.WriteLine("An error occurred: " + ex.Message);
                    break;
                }
            }

            // Dispose presentation
            pres.Dispose();
        }
    }
}