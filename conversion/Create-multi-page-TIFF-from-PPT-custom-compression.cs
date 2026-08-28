// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create multi page TIFF from PPT custom compression using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation (PPTX) to a multi‑page

// TIFF image using LZW compression and custom DPI settings with Aspose.Slides

// for .NET. The example loads a presentation, configures TIFF export options,

// and saves the result as a multi‑page TIFF file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, TIFF, Multi‑page, LZW, Compression,

// DPI, Presentation Conversion, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to multi‑page TIFF with custom compression.

// - Build .NET tools for archiving or printing PowerPoint slides as TIFF images.

// - Integrate slide‑to‑image conversion into document processing pipelines.

// - Apply specific DPI and compression settings for optimized TIFF output.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.tiff");



        if (!File.Exists(inputPath))

        {

            // Input file does not exist.

            return;

        }



        try

        {

            Presentation presentation = new Presentation(inputPath);

            TiffOptions tiffOptions = new TiffOptions

            {

                CompressionType = TiffCompressionTypes.LZW,

                DpiX = 150,

                DpiY = 150

            };

            presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported.

        }

        catch (Exception)

        {

            // Handle other exceptions.

        }

    }

}

