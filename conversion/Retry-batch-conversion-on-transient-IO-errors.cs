using System;
using System.IO;
using System.Threading;
using Aspose.Slides.Export;

namespace BatchConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output directories
            string inputDirectory = "InputPresentations";
            string outputDirectory = "OutputPresentations";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine($"Input directory does not exist: {inputDirectory}");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all files in the input directory
            string[] files = Directory.GetFiles(inputDirectory);
            foreach (var filePath in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string outputPath = Path.Combine(outputDirectory, $"{fileName}.pdf");

                int maxRetries = 3;
                int attempt = 0;
                bool success = false;

                while (attempt < maxRetries && !success)
                {
                    try
                    {
                        // Load the presentation
                        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))
                        {
                            // Save as PDF (or any desired format)
                            presentation.Save(outputPath, SaveFormat.Pdf);
                        }

                        Console.WriteLine($"Successfully converted: {filePath}");
                        success = true;
                    }
                    catch (IOException ioEx)
                    {
                        // Transient I/O error, retry after a short delay
                        attempt++;
                        Console.WriteLine($"I/O error on attempt {attempt} for file {filePath}: {ioEx.Message}");
                        if (attempt < maxRetries)
                        {
                            Thread.Sleep(2000); // wait 2 seconds before retry
                        }
                        else
                        {
                            Console.WriteLine($"Failed to convert after {maxRetries} attempts: {filePath}");
                        }
                    }
                    catch (Aspose.Slides.PptUnsupportedFormatException)
                    {
                        // Format not supported
                        Console.WriteLine($"Unsupported format (PPT) for file: {filePath}");
                        break;
                    }
                    catch (Aspose.Slides.PptxUnsupportedFormatException)
                    {
                        // Format not supported
                        Console.WriteLine($"Unsupported format (PPTX) for file: {filePath}");
                        break;
                    }
                    catch (Exception ex)
                    {
                        // Other exceptions
                        Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
                        break;
                    }
                }
            }

            // Ensure all resources are disposed before exiting
            Console.WriteLine("Batch conversion completed.");
        }
    }
}