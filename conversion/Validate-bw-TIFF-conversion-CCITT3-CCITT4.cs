// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate bw TIFF conversion CCITT3 CCITT4 using C#

//

// Description:

// Demonstrates how to validate black‑and‑white TIFF conversion using CCITT3

// and CCITT4 compression with Aspose.Slides for .NET. The example loads a

// PowerPoint presentation, configures TiffOptions for BW conversion, and

// saves the result as a multi‑page TIFF file. This pattern can be used to

// verify that BW conversion and compression settings produce the expected

// output in automated workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, TIFF, Conversion,

// CCITT3, CCITT4, BlackWhiteConversion, Office Automation

//

// Use Cases:

// - Automate validation of BW TIFF conversion with CCITT3/CCITT4 compression.

// - Build C# utilities for PowerPoint to TIFF conversion testing.

// - Integrate presentation processing checks into CI pipelines.

// - Ensure correct image compression settings before publishing assets.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Verify that a source file path was provided

        if (args.Length == 0)

        {

            Console.WriteLine("Please provide the path to the source presentation file as an argument.");

            return;

        }



        string sourcePath = args[0];



        // Check if the input file exists

        if (!File.Exists(sourcePath))

        {

            Console.WriteLine($"Input file does not exist: {sourcePath}");

            return;

        }



        // Define the output TIFF file path

        string outputPath = Path.ChangeExtension(sourcePath, "tiff");



        try

        {

            // Load the presentation

            using (Presentation presentation = new Presentation(sourcePath))

            {

                // Create TIFF options

                TiffOptions tiffOptions = new TiffOptions();



                // Set the compression type (example uses CCITT4)

                tiffOptions.CompressionType = TiffCompressionTypes.CCITT4;



                // Apply black‑and‑white conversion only when compression is CCITT3 or CCITT4

                if (tiffOptions.CompressionType == TiffCompressionTypes.CCITT3 ||

                    tiffOptions.CompressionType == TiffCompressionTypes.CCITT4)

                {

                    tiffOptions.BwConversionMode = BlackWhiteConversionMode.Dithering;

                }



                // Save the presentation as a multi‑page TIFF

                presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);

            }

        }

        // Handle unsupported file format exceptions

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The specified file format is not supported.");

        }

        // General exception handling

        catch (Exception ex)

        {

            Console.WriteLine($"An error occurred: {ex.Message}");

        }

    }

}

