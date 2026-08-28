// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set CCITT4 compression and Dithering black‑white mode using C#

//

// Description:

// Demonstrates how to configure CCITT4 compression and Dithering black‑white

// conversion mode when exporting a PowerPoint presentation to a TIFF image

// using Aspose.Slides for .NET. The example loads a PPTX file, applies the

// specified TIFF options, and saves the result as a TIFF file. This pattern

// can be used in console applications or automated workflows that require

// high‑compression, black‑and‑white TIFF output.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, TIFF, CCITT4, Compression, Dithering,

// BlackWhiteConversionMode, Presentation Export, .NET

//

// Use Cases:

// - Generate compact black‑and‑white TIFF images from presentations.

// - Automate batch conversion of PPTX files to CCITT4‑compressed TIFFs.

// - Integrate high‑compression image export into document processing pipelines.

// - Validate TIFF export settings in CI/CD pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

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

            TiffOptions options = new TiffOptions();

            options.CompressionType = TiffCompressionTypes.CCITT4;

            options.BwConversionMode = BlackWhiteConversionMode.Dithering;

            presentation.Save(outputPath, SaveFormat.Tiff, options);

            presentation.Dispose();

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

