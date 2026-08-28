// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set bw conversion mode to dithering using C#

//

// Description:

// Demonstrates how to configure black‑and‑white conversion mode to dithering

// when exporting a PowerPoint presentation to a TIFF image using Aspose.Slides

// for .NET. The example loads a PPTX file, sets TIFF export options with

// CCITT4 compression and Dithering mode, and saves the result as a BW TIFF.

// This pattern can be used in console applications or automated workflows

// that require high‑quality monochrome image output.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, TIFF, Black‑and‑White, Dithering,

// CCITT4, Presentation Export, Image Conversion, .NET

//

// Use Cases:

// - Convert PPTX slides to monochrome TIFF images with dithering for printing.

// - Automate generation of BW TIFF assets from presentations.

// - Integrate Aspose.Slides export settings into .NET batch processing tools.

// - Ensure consistent image quality when preparing slides for archival.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

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

            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);



            // Configure TIFF options for black‑and‑white conversion with dithering

            Aspose.Slides.Export.TiffOptions options = new Aspose.Slides.Export.TiffOptions();

            options.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.CCITT4;

            options.BwConversionMode = Aspose.Slides.Export.BlackWhiteConversionMode.Dithering;



            // Save the presentation as a black‑and‑white TIFF

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, options);

        }

        catch (Exception ex)

        {

            // Handle errors such as unsupported format

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

