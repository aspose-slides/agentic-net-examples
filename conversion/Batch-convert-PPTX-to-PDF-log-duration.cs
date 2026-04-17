using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConversion
{
    public class Program
    {
        public class Result
        {
            public string File { get; set; }
            public long DurationMs { get; set; }
        }

        public static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("No input files specified.");
                return;
            }

            List<Result> results = new List<Result>();

            foreach (string inputPath in args)
            {
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                try
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    using (Presentation pres = new Presentation(inputPath))
                    {
                        string outputDirectory = Path.GetDirectoryName(inputPath);
                        string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_out.pptx";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }

                    stopwatch.Stop();

                    Result result = new Result();
                    result.File = inputPath;
                    result.DurationMs = stopwatch.ElapsedMilliseconds;
                    results.Add(result);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine($"Format not supported for file: {inputPath}");
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., external URL issues)
                    Console.WriteLine($"Error processing file {inputPath}: {ex.Message}");
                }
            }

            string jsonOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "results.json");
            string json = JsonSerializer.Serialize(results, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonOutputPath, json);
            Console.WriteLine($"Conversion results written to {jsonOutputPath}");
        }
    }
}