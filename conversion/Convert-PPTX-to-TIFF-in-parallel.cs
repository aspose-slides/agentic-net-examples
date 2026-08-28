// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert multiple presentations to TIFF in parallel using C#

//

// Description:

// Demonstrates how to load presentation files supplied via command‑line

// arguments, convert each to a multi‑page TIFF concurrently using

// Parallel.ForEach, and save the output using Aspose.Slides for .NET.

// The example includes basic validation, error handling for missing files

// and unsupported formats, and limits concurrency to the number of logical

// processors.

//

// Keywords:

// C#, Aspose.Slides, .NET, Parallel, Multi‑threading, TIFF conversion,

// Presentation conversion, PowerPoint, PPTX, PPT, Command‑line, Batch processing

//

// Use Cases:

// - Automate batch conversion of PowerPoint presentations to TIFF.

// - Build command‑line tools for high‑throughput presentation processing.

// - Integrate parallel TIFF conversion into CI/CD pipelines.

// - Reduce conversion time for large collections of presentation files.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Threading.Tasks;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ParallelTiffConversion

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input file paths are taken from command‑line arguments

            string[] inputFiles = args;



            if (inputFiles == null || inputFiles.Length == 0)

            {

                Console.WriteLine("Please provide presentation file paths as arguments.");

                return;

            }



            // Limit concurrency to the number of logical processors

            ParallelOptions parallelOptions = new ParallelOptions

            {

                MaxDegreeOfParallelism = Environment.ProcessorCount

            };



            Parallel.ForEach(inputFiles, parallelOptions, (inputPath) =>

            {

                try

                {

                    // Verify that the source file exists

                    if (!File.Exists(inputPath))

                    {

                        Console.WriteLine($"File not found: {inputPath}");

                        return;

                    }



                    // Load the presentation

                    using (Presentation presentation = new Presentation(inputPath))

                    {

                        // Prepare TIFF options (default options are sufficient for basic conversion)

                        TiffOptions tiffOptions = new TiffOptions();



                        // Determine output file path (same folder, same name with .tiff extension)

                        string outputPath = Path.ChangeExtension(inputPath, ".tiff");



                        // Save the presentation as a multi‑page TIFF

                        presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);

                        Console.WriteLine($"Converted '{inputPath}' to TIFF successfully.");

                    }

                }

                catch (NotSupportedException)

                {

                    // Format not supported

                    Console.WriteLine($"The format of '{inputPath}' is not supported for conversion.");

                }

                catch (Exception ex)

                {

                    // General exception handling

                    Console.WriteLine($"Error processing '{inputPath}': {ex.Message}");

                }

            });

        }

    }

}

