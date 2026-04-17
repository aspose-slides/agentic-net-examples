using System;
using System.IO;
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesRetryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Retry loop for transient network errors (e.g., when loading from a URL)
            int maxAttempts = 5;
            int attempt = 0;
            bool succeeded = false;

            while (attempt < maxAttempts && !succeeded)
            {
                try
                {
                    // Load presentation
                    Presentation presentation = new Presentation(inputPath);

                    // Save presentation in desired format
                    presentation.Save(outputPath, SaveFormat.Pdf);

                    // Dispose resources
                    presentation.Dispose();

                    succeeded = true;
                    Console.WriteLine("Conversion succeeded on attempt " + (attempt + 1));
                }
                catch (WebException)
                {
                    // Transient network error, retry
                    attempt++;
                    Console.WriteLine("Transient network error encountered. Retry attempt " + attempt);
                    if (attempt >= maxAttempts)
                    {
                        Console.WriteLine("Maximum retry attempts reached. Conversion failed.");
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine("The requested format is not supported.");
                    break;
                }
                catch (Exception ex)
                {
                    // Other unexpected errors
                    Console.WriteLine("An error occurred: " + ex.Message);
                    break;
                }
            }

            // Ensure presentation is saved before exit (already saved in the try block)
        }
    }
}