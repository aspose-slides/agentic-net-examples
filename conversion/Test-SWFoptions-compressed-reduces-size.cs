// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Test SWFoptions compressed reduces size using C#

//

// Description:

// Demonstrates how to compare compressed and uncompressed SWF output sizes

// when converting a PPTX presentation using Aspose.Slides for .NET. The example

// loads a PPTX file, saves it twice (with default compression and with

// compression disabled), and prints the resulting file sizes to verify that

// compression reduces the SWF size.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Compression, SwfOptions,

// File Size Comparison, Presentation Conversion, Office Automation

//

// Use Cases:

// - Verify that SWF compression reduces output file size.

// - Build utilities for PPTX to SWF conversion with configurable compression.

// - Automate testing of Aspose.Slides compression settings.

// - Integrate SWF generation into .NET applications with size optimization.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SwfCompressionTest

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "sample.pptx";

            string outputCompressedPath = "sample_compressed.swf";

            string outputUncompressedPath = "sample_uncompressed.swf";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation presentation = new Presentation(inputPath);



                // Save with default compression (Compressed = true)

                SwfOptions compressedOptions = new SwfOptions(); // Compressed is true by default

                presentation.Save(outputCompressedPath, SaveFormat.Swf, compressedOptions);



                // Save with compression disabled (Compressed = false)

                SwfOptions uncompressedOptions = new SwfOptions();

                uncompressedOptions.Compressed = false;

                presentation.Save(outputUncompressedPath, SaveFormat.Swf, uncompressedOptions);



                // Dispose the presentation

                presentation.Dispose();



                // Compare file sizes

                long compressedSize = new FileInfo(outputCompressedPath).Length;

                long uncompressedSize = new FileInfo(outputUncompressedPath).Length;



                Console.WriteLine("Compressed SWF size: " + compressedSize + " bytes");

                Console.WriteLine("Uncompressed SWF size: " + uncompressedSize + " bytes");



                if (compressedSize < uncompressedSize)

                {

                    Console.WriteLine("Compression reduced the file size.");

                }

                else

                {

                    Console.WriteLine("Compression did not reduce the file size.");

                }

            }

            catch (NotSupportedException ex)

            {

                // Handle unsupported format exception

                Console.WriteLine("The file format is not supported: " + ex.Message);

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

