// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Disable compression for high quality PPTX using C#

//

// Description:

// Demonstrates how to read a configuration file, load each listed PowerPoint

// presentation marked as high‑quality, and save it without ZIP64 compression

// using Aspose.Slides for .NET. The example shows batch processing of PPTX

// files, disabling compression to preserve maximum image quality.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Disable Compression, High Quality,

// Batch Processing, Configuration File, Presentation Automation

//

// Use Cases:

// - Process multiple presentations flagged for high quality.

// - Generate PPTX files without ZIP64 compression for archival or printing.

// - Integrate high‑quality PPTX export into .NET automation tools.

// - Validate and transform presentations based on external configuration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace PresentationCompressionDemo

{

    class Program

    {

        static void Main(string[] args)

        {

            // Path to configuration file (each line: <presentationPath>|high)

            string configFilePath = "config.txt";



            if (!File.Exists(configFilePath))

            {

                Console.WriteLine("Configuration file not found.");

                return;

            }



            string[] configLines = File.ReadAllLines(configFilePath);



            foreach (string line in configLines)

            {

                if (string.IsNullOrWhiteSpace(line))

                {

                    continue;

                }



                // Expected format: <filePath>|high (case‑insensitive)

                string[] parts = line.Split('|');

                string inputPath = parts[0].Trim();

                bool isHighQuality = parts.Length > 1 && parts[1].Trim().Equals("high", StringComparison.OrdinalIgnoreCase);



                if (!File.Exists(inputPath))

                {

                    Console.WriteLine($"Input file does not exist: {inputPath}");

                    continue;

                }



                if (!isHighQuality)

                {

                    // Skip non‑high‑quality presentations

                    continue;

                }



                Presentation presentation = null;

                try

                {

                    // Load the presentation

                    presentation = new Presentation(inputPath);



                    // Determine output path

                    string outputDirectory = Path.GetDirectoryName(inputPath);

                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_noCompression.pptx";

                    string outputPath = Path.Combine(outputDirectory, outputFileName);



                    // Save without compression (disable ZIP64 usage)

                    presentation.Save(outputPath, SaveFormat.Pptx, new PptxOptions()

                    {

                        Zip64Mode = Zip64Mode.Never

                    });



                    Console.WriteLine($"Saved without compression: {outputPath}");

                }

                catch (Exception ex)

                {

                    // Handle unsupported format or other errors

                    Console.WriteLine($"Error processing file '{inputPath}': {ex.Message}");

                }

                finally

                {

                    // Ensure resources are released

                    if (presentation != null)

                    {

                        presentation.Dispose();

                    }

                }

            }

        }

    }

}

