// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply 8bpp indexed to TIFF and compare size using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation to TIFF images using

// Aspose.Slides for .NET with the default pixel format and with an 8bpp indexed

// pixel format, then compares the resulting file sizes. The example shows the

// required presentation‑processing steps, TIFF options configuration, and

// basic size‑reduction calculation in a standalone console application.

// Developers can use this pattern to automate PPTX to TIFF conversion and

// evaluate compression benefits.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, TIFF, 8bpp indexed, ImagePixelFormat,

// Presentation conversion, File size comparison, Office automation

//

// Use Cases:

// - Convert PPTX files to TIFF with custom pixel formats.

// - Measure storage savings when using 8bpp indexed TIFF.

// - Build .NET tools for batch conversion and size analysis of presentations.

// - Integrate TIFF conversion into document processing pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AsposeSlidesTiffExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "input.pptx";

            string defaultTiffPath = "output_default.tiff";

            string customTiffPath = "output_custom.tiff";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Save the presentation to TIFF with default settings

                    presentation.Save(defaultTiffPath, SaveFormat.Tiff);



                    // Configure TIFF options with 8bpp indexed pixel format

                    TiffOptions tiffOptions = new TiffOptions();

                    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;



                    // Save the presentation to TIFF using custom pixel format

                    presentation.Save(customTiffPath, SaveFormat.Tiff, tiffOptions);

                }



                // Get file sizes

                long defaultSize = new FileInfo(defaultTiffPath).Length;

                long customSize = new FileInfo(customTiffPath).Length;



                // Output size comparison

                Console.WriteLine("Default TIFF size (bytes): " + defaultSize);

                Console.WriteLine("Custom TIFF size (bytes): " + customSize);

                if (defaultSize > 0)

                {

                    double reductionPercent = ((double)(defaultSize - customSize) / defaultSize) * 100;

                    Console.WriteLine("Size reduction: " + reductionPercent.ToString("F2") + "%");

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: format not supported

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., file I/O errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

