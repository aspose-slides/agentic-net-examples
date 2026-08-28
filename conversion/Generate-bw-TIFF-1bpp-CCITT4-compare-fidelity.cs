// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Generate bw TIFF 1bpp CCITT4 compare fidelity using C#

//

// Description:

// Demonstrates how to generate a black‑and‑white TIFF image with 1‑bpp pixel

// format and CCITT4 compression from a PowerPoint presentation using

// Aspose.Slides for .NET. The example also outlines where to add visual fidelity

// comparison logic between the original slides and the generated TIFF.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Generate, TIFF, 1bpp, CCITT4,

// Black‑and‑White, Image Conversion, Presentation Processing

//

// Use Cases:

// - Automate creation of high‑compression black‑and‑white TIFF files from PPTX.

// - Build tools for validating visual fidelity of converted slide images.

// - Integrate slide‑to‑TIFF conversion into .NET applications or CI pipelines.

// - Perform pixel‑wise comparison of original slides versus generated TIFFs.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Define input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.tif";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file not found.");

            return;

        }



        try

        {

            // Load the presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Configure TIFF options: 1bpp pixel format, CCITT4 compression, dithering conversion

            Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();

            tiffOptions.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.CCITT4;

            tiffOptions.BwConversionMode = Aspose.Slides.Export.BlackWhiteConversionMode.Dithering;

            tiffOptions.PixelFormat = Aspose.Slides.Export.ImagePixelFormat.Format1bppIndexed;



            // Save the presentation as a black‑and‑white TIFF

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);



            // Compare visual fidelity between original and TIFF (implementation omitted)

            // TODO: Load both images and perform pixel‑wise comparison.



            // Dispose the presentation

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported.");

        }

        catch (Exception ex)

        {

            // General error handling

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

