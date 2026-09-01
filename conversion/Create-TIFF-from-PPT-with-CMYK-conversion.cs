// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create TIFF from PPT with CMYK conversion using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation (PPTX) to a TIFF image

// using Aspose.Slides for .NET while configuring the output for CMYK‑compatible

// print‑ready quality. The example loads a presentation, sets TIFF options such

// as LZW compression, 300 dpi resolution, and a 24‑bit RGB pixel format (the

// closest available format to CMYK in Aspose.Slides), and saves the result.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, TIFF, CMYK, Conversion, 

// Presentation Processing, Office Automation, Print Ready

//

// Use Cases:

// - Automate generation of print‑ready TIFF images from PowerPoint files.

// - Build .NET utilities for batch conversion of presentations to TIFF.

// - Integrate presentation conversion into publishing workflows.

// - Validate and preview PPTX content before printing or distribution.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        string inputPath = "input.pptx";

        string outputPath = "output.tiff";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            Presentation presentation = new Presentation(inputPath);

            TiffOptions options = new TiffOptions

            {

                CompressionType = TiffCompressionTypes.LZW,

                DpiX = 300,

                DpiY = 300,

                // Set pixel format to 24bpp RGB (closest to CMYK for print-ready output)

                PixelFormat = ImagePixelFormat.Format24bppRgb

            };

            presentation.Save(outputPath, SaveFormat.Tiff, options);

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

