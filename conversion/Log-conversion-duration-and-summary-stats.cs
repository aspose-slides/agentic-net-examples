// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Log conversion duration and summary stats using C#

//

// Description:

// Demonstrates how to log conversion duration and summary statistics for a batch

// of presentations using C# and Aspose.Slides for .NET. The example processes

// multiple input files, applies a simple slide transition change, saves the

// converted files, and outputs per‑file conversion times along with total and

// average processing metrics.

//

// Keywords:

// C#, Aspose.Slides for .NET, PowerPoint, PPTX, ODP, batch conversion, duration,

// performance logging, summary statistics, presentation processing, automation

//

// Use Cases:

// - Perform batch conversion of various presentation formats to PPTX.

// - Record conversion time for each file and overall batch performance.

// - Apply uniform slide settings (e.g., transition duration) during conversion.

// - Integrate conversion timing into monitoring or reporting tools.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Diagnostics;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlideConversionBatch

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input files (could be passed via args)

            var inputFiles = args.Length > 0 ? args : new string[]

            {

                "input1.pptx",

                "input2.ppt",

                "input3.odp"

            };



            var outputDirectory = "Converted";

            if (!Directory.Exists(outputDirectory))

            {

                Directory.CreateDirectory(outputDirectory);

            }



            var totalStopwatch = Stopwatch.StartNew();

            var processedCount = 0;

            var totalMilliseconds = 0L;



            foreach (var inputPath in inputFiles)

            {

                if (!File.Exists(inputPath))

                {

                    Console.WriteLine($"File not found: {inputPath}");

                    continue;

                }



                var fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);

                var outputPath = Path.Combine(outputDirectory, $"{fileNameWithoutExt}_converted.pptx");



                var fileStopwatch = Stopwatch.StartNew();

                try

                {

                    using (var presentation = new Presentation(inputPath))

                    {

                        // Example operation: set slide transition duration for all slides

                        foreach (ISlide slide in presentation.Slides)

                        {

                            slide.SlideShowTransition.Duration = 2000; // 2 seconds

                        }



                        // Save the presentation

                        presentation.Save(outputPath, SaveFormat.Pptx);

                    }



                    fileStopwatch.Stop();

                    var elapsedMs = fileStopwatch.ElapsedMilliseconds;

                    Console.WriteLine($"Converted '{inputPath}' in {elapsedMs} ms.");

                    totalMilliseconds += elapsedMs;

                    processedCount++;

                }

                catch (NotSupportedException)

                {

                    // Format not supported

                    Console.WriteLine($"Format not supported for file: {inputPath}");

                }

                catch (Exception ex)

                {

                    // General exception handling (e.g., external URL issues)

                    Console.WriteLine($"Error processing '{inputPath}': {ex.Message}");

                }

            }



            totalStopwatch.Stop();

            Console.WriteLine("Batch processing completed.");

            Console.WriteLine($"Total files processed: {processedCount}");

            Console.WriteLine($"Total time: {totalMilliseconds} ms");

            if (processedCount > 0)

            {

                Console.WriteLine($"Average time per file: {totalMilliseconds / processedCount} ms");

            }

        }

    }

}

