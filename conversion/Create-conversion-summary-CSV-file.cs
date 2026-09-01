// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create conversion summary CSV file using C#

//

// Description:

// Demonstrates how to convert PowerPoint presentations to PDF using Aspose.Slides for .NET

// and generate a CSV summary containing the input file name, output PDF size, and conversion time.

// The example processes multiple presentation files supplied as command‑line arguments

// and writes the results to a standalone CSV file.

//

// Keywords:

// C#, PowerPoint, PPTX, PDF, Aspose.Slides for .NET, Conversion, Summary, CSV, File I/O, Presentation Processing

//

// Use Cases:

// - Automate batch conversion of PPTX files to PDF with performance metrics.

// - Build C# utilities for PowerPoint presentation processing and reporting.

// - Generate conversion logs for validation or auditing purposes.

// - Integrate presentation conversion into .NET automation pipelines.

// -----------------------------------------------------------------------------

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

