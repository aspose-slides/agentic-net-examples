using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides.Export;

namespace PresentationUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output CSV file path
            string csvPath = Path.Combine(Environment.CurrentDirectory, "summary.csv");
            // Create or overwrite the CSV file and write header
            using (StreamWriter writer = new StreamWriter(csvPath, false))
            {
                writer.WriteLine("InputFile,OutputSizeBytes,ConversionTimeMs");
                // Process each input file passed as argument
                foreach (string inputPath in args)
                {
                    // Check if the input file exists
                    if (!File.Exists(inputPath))
                    {
                        // Skip non‑existent files
                        continue;
                    }

                    // Prepare output file path (same name with _out.pptx suffix)
                    string inputFileName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), inputFileName + "_out.pptx");

                    // Measure conversion time
                    Stopwatch stopwatch = new Stopwatch();
                    try
                    {
                        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                        {
                            stopwatch.Start();
                            // Save the presentation in PPTX format
                            pres.Save(outputPath, SaveFormat.Pptx);
                            stopwatch.Stop();
                        }

                        // Get output file size
                        long outputSize = new FileInfo(outputPath).Length;

                        // Write CSV line
                        writer.WriteLine($"{Path.GetFileName(inputPath)},{outputSize},{stopwatch.ElapsedMilliseconds}");
                    }
                    catch (NotSupportedException)
                    {
                        // Format not supported – write comment line in CSV
                        writer.WriteLine($"{Path.GetFileName(inputPath)},UnsupportedFormat,0");
                    }
                    catch (Exception ex)
                    {
                        // General exception handling (e.g., I/O errors)
                        writer.WriteLine($"{Path.GetFileName(inputPath)},Error,{0}");
                    }
                }
            }
        }
    }
}