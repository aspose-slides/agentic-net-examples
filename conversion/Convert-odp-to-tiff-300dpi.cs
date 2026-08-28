// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert ODP to TIFF 300 DPI using C#

//

// Description:

// Demonstrates how to convert ODP files to TIFF images at 300 DPI using C# and

// Aspose.Slides for .NET. The example processes all .odp files in a specified

// folder (or the current directory) and saves each as a high‑quality TIFF file.

// Developers can use this pattern to automate batch conversion of OpenDocument

// presentations to raster images.

//

// Keywords:

// C#, ODP, TIFF, 300DPI, Aspose.Slides for .NET, Conversion, Batch Processing,

// Presentation Automation

//

// Use Cases:

// - Batch convert ODP presentations to high‑resolution TIFF images.

// - Integrate ODP to TIFF conversion into .NET command‑line tools.

// - Prepare presentation assets for printing or archival.

// - Automate image generation from OpenDocument slides in CI pipelines.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace OdpToTiff

{

    class Program

    {

        static void Main(string[] args)

        {

            // Determine input folder (argument or current directory)

            var inputFolder = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();



            // Verify folder exists

            if (!Directory.Exists(inputFolder))

            {

                Console.WriteLine($"Input folder does not exist: {inputFolder}");

                return;

            }



            // Get all ODP files in the folder

            var odpFiles = Directory.GetFiles(inputFolder, "*.odp");



            foreach (var odpPath in odpFiles)

            {

                // Verify file exists

                if (!File.Exists(odpPath))

                {

                    Console.WriteLine($"File not found: {odpPath}");

                    continue;

                }



                try

                {

                    // Load presentation

                    using (var presentation = new Presentation(odpPath))

                    {

                        // Configure TIFF options for 300 DPI

                        var tiffOptions = new TiffOptions();

                        tiffOptions.DpiX = 300;

                        tiffOptions.DpiY = 300;



                        // Prepare output path

                        var outputFileName = Path.GetFileNameWithoutExtension(odpPath) + ".tiff";

                        var outputPath = Path.Combine(inputFolder, outputFileName);



                        // Save as high‑quality TIFF

                        presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);

                    }

                }

                catch (InvalidOperationException)

                {

                    // Format not supported

                    Console.WriteLine($"Format not supported for file: {odpPath}");

                }

                catch (Exception ex)

                {

                    // General error handling

                    Console.WriteLine($"Error processing file {odpPath}: {ex.Message}");

                }

            }

        }

    }

}

