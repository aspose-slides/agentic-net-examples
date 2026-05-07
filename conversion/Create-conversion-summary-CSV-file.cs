using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides.Export;

namespace PresentationConversionUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check if any input files are provided
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please provide at least one presentation file path as an argument.");
                return;
            }

            string csvPath = "summary.csv";

            // Create CSV file and write header
            using (StreamWriter csvWriter = new StreamWriter(csvPath, false))
            {
                csvWriter.WriteLine("InputFile,OutputSizeBytes,ConversionTimeMs");

                foreach (string inputPath in args)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.WriteLine($"Input file does not exist: {inputPath}");
                        continue;
                    }

                    string outputPath = Path.ChangeExtension(inputPath, ".pdf");
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    try
                    {
                        // Load presentation and convert to PDF
                        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                        {
                            // Save using the generic convert-without-xps-options rule
                            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
                        }
                    }
                    catch (NotSupportedException)
                    {
                        // Format not supported
                        Console.WriteLine($"Conversion format not supported for file: {inputPath}");
                        continue;
                    }
                    catch (Exception ex)
                    {
                        // Handle other unexpected exceptions
                        Console.WriteLine($"Error processing file {inputPath}: {ex.Message}");
                        continue;
                    }
                    finally
                    {
                        stopwatch.Stop();
                    }

                    // Get output file size
                    long outputSize = new FileInfo(outputPath).Length;

                    // Write summary line to CSV
                    csvWriter.WriteLine($"{Path.GetFileName(inputPath)},{outputSize},{stopwatch.ElapsedMilliseconds}");
                }
            }

            Console.WriteLine($"Conversion summary written to {csvPath}");
        }
    }
}