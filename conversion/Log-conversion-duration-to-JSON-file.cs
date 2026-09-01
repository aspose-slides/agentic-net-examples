// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Log conversion duration to JSON file using C#

//

// Description:

// Demonstrates how to batch convert PowerPoint and OpenDocument presentations

// (PPT, PPTX, ODP) to PDF using Aspose.Slides for .NET while measuring the

// conversion time for each file and logging the results to a JSON file.

// The example includes directory handling, format validation, error handling,

// and JSON serialization of conversion durations.

//

// Keywords:

// C#, PowerPoint, PPTX, ODP, PDF, Aspose.Slides for .NET, Conversion, Duration,

// Json, File, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate batch conversion of presentations to PDF with performance logging.

// - Build C# tools for PowerPoint and ODP processing in .NET applications.

// - Generate conversion reports for monitoring and optimization.

// - Validate and log presentation workflow timings before publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Diagnostics;

using System.Collections.Generic;

using System.Text.Json;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace BatchConversion

{

    class Program

    {

        static void Main(string[] args)

        {

            // Determine input and output directories

            string inputDir = args.Length > 0 ? args[0] : "input";

            string outputDir = args.Length > 1 ? args[1] : "output";

            string jsonPath = Path.Combine(outputDir, "conversion_log.json");



            // Ensure the output directory exists

            if (!Directory.Exists(outputDir))

            {

                Directory.CreateDirectory(outputDir);

            }



            List<ConversionResult> results = new List<ConversionResult>();



            // Verify input directory exists

            if (!Directory.Exists(inputDir))

            {

                Console.WriteLine("Input directory does not exist: " + inputDir);

                return;

            }



            string[] files = Directory.GetFiles(inputDir, "*.*", SearchOption.TopDirectoryOnly);

            foreach (string filePath in files)

            {

                // Supported formats: PPT, PPTX, ODP

                string extension = Path.GetExtension(filePath).ToLowerInvariant();

                if (extension != ".ppt" && extension != ".pptx" && extension != ".odp")

                {

                    // format not supported

                    Console.WriteLine("Unsupported format: " + filePath);

                    continue;

                }



                // Verify file existence

                if (!File.Exists(filePath))

                {

                    Console.WriteLine("File not found: " + filePath);

                    continue;

                }



                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();



                try

                {

                    using (Presentation presentation = new Presentation(filePath))

                    {

                        string outputFileName = Path.GetFileNameWithoutExtension(filePath) + ".pdf";

                        string outputPath = Path.Combine(outputDir, outputFileName);

                        // Save presentation as PDF

                        presentation.Save(outputPath, SaveFormat.Pdf);

                    }

                }

                catch (NotSupportedException)

                {

                    // format not supported

                    Console.WriteLine("Not supported format for file: " + filePath);

                    continue;

                }

                catch (Exception ex)

                {

                    Console.WriteLine("Error processing file: " + filePath);

                    Console.WriteLine(ex.Message);

                    continue;

                }



                stopwatch.Stop();



                ConversionResult result = new ConversionResult();

                result.FileName = Path.GetFileName(filePath);

                result.DurationMilliseconds = stopwatch.ElapsedMilliseconds;

                results.Add(result);

            }



            // Write conversion results to JSON file

            try

            {

                string json = JsonSerializer.Serialize(results, new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(jsonPath, json);

            }

            catch (Exception ex)

            {

                Console.WriteLine("Failed to write JSON log: " + ex.Message);

            }

        }



        private class ConversionResult

        {

            public string FileName { get; set; }

            public long DurationMilliseconds { get; set; }

        }

    }

}

