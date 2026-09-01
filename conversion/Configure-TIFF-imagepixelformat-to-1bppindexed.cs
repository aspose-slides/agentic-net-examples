// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Configure TIFF imagepixelformat to 1bppindexed using C#

//

// Description:

// Demonstrates how to configure the TIFF ImagePixelFormat to 1bpp indexed

// using C# and Aspose.Slides for .NET. The example loads a PowerPoint

// presentation, sets the TIFF export options to use a 1‑bit per pixel indexed

// format for minimal file size, and saves the result as a TIFF image.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Configure, TIFF,

// ImagePixelFormat, 1BppIndexed, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX slides to compact 1bpp indexed TIFF images.

// - Build C# utilities for PowerPoint presentation processing with custom

//   image export settings.

// - Generate low‑size TIFF files for archival or transmission purposes.

// - Validate presentation workflows that require specific image pixel formats.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace TiffConversionExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.tiff";



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



                // Configure TIFF options with 1bpp indexed pixel format for minimal size

                TiffOptions tiffOptions = new TiffOptions();

                tiffOptions.PixelFormat = ImagePixelFormat.Format1bppIndexed;



                // Save the presentation as TIFF using the configured options

                presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);



                // Dispose the presentation object

                presentation.Dispose();



                Console.WriteLine("Presentation successfully saved as TIFF: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Handle unsupported file format

                // Format not supported

                Console.WriteLine("The provided file format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

