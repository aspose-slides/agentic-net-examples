// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch process PPT to TIFF LZW 150DPI using C#

//

// Description:

// Demonstrates how to batch process one or more PowerPoint files (PPT/PPTX) to

// TIFF images using LZW compression at 150 DPI with Aspose.Slides for .NET.

// The example accepts file paths as command‑line arguments, converts each

// presentation, and saves the output TIFF alongside the source file.

// This pattern can be used to automate high‑volume conversion tasks in .NET

// applications.

//

// Keywords:

// C#, PowerPoint, PPT, PPTX, TIFF, LZW, 150DPI, Aspose.Slides for .NET, Batch,

// Process, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate batch conversion of PPT/PPTX files to compressed TIFF images.

// - Build command‑line tools for PowerPoint presentation archiving.

// - Integrate TIFF export with specific compression and resolution settings

//   into .NET workflows.

// - Validate and preprocess presentations before publishing or distribution.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace BatchTiffCompression

{

    class Program

    {

        static void Main(string[] args)

        {

            // Check if any arguments are provided

            if (args == null || args.Length == 0)

            {

                Console.WriteLine("Please provide PPT file paths as arguments.");

                return;

            }



            // Process each input file

            foreach (string inputPath in args)

            {

                try

                {

                    // Verify that the file exists

                    if (!File.Exists(inputPath))

                    {

                        Console.WriteLine($"File not found: {inputPath}");

                        continue;

                    }



                    // Load the presentation

                    Presentation presentation = new Presentation(inputPath);



                    // Configure TIFF options: LZW compression and 150 DPI

                    TiffOptions tiffOptions = new TiffOptions();

                    tiffOptions.CompressionType = TiffCompressionTypes.LZW;

                    tiffOptions.DpiX = 150;

                    tiffOptions.DpiY = 150;



                    // Build the output file path

                    string directory = Path.GetDirectoryName(inputPath);

                    string filenameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);

                    string outputPath = Path.Combine(directory, filenameWithoutExt + "_compressed.tiff");



                    // Save the presentation as TIFF with the specified options

                    presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);



                    // Dispose the presentation before exiting the loop

                    presentation.Dispose();



                    Console.WriteLine($"Processed: {inputPath} -> {outputPath}");

                }

                catch (NotSupportedException)

                {

                    // Handle unsupported format

                    Console.WriteLine($"Format not supported for file: {inputPath}");

                }

                catch (Exception ex)

                {

                    // General error handling

                    Console.WriteLine($"Error processing file {inputPath}: {ex.Message}");

                }

            }

        }

    }

}

