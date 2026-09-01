// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Compress embedded fonts in presentation using C#

//

// Description:

// Demonstrates how to compress embedded fonts in a PowerPoint presentation

// using Aspose.Slides for .NET. The example loads a PPTX file, applies the

// low‑code compression API to reduce the size of embedded fonts, and saves the

// result. It can be used as a standalone console utility for automating font

// compression in PPTX workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Compress, Embedded Fonts, 

// Presentation Processing, Office Automation, Low‑Code API

//

// Use Cases:

// - Reduce file size of presentations by compressing embedded fonts.

// - Integrate font compression into batch processing tools.

// - Prepare PPTX files for distribution with smaller payloads.

// - Automate PowerPoint optimization in CI/CD pipelines.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using Aspose.Slides.LowCode;



class Program

{

    static void Main(string[] args)

    {

        // Validate arguments

        if (args.Length < 2)

        {

            Console.WriteLine("Usage: <program> <input.pptx> <output.pptx>");

            return;

        }



        // Input and output file paths

        string __inputPath__ = args[0];

        string __outputPath__ = args[1];



        // Check if input file exists

        if (!File.Exists(__inputPath__))

        {

            Console.WriteLine("Input file does not exist: " + __inputPath__);

            return;

        }



        try

        {

            // Load presentation

            Aspose.Slides.Presentation __presentation__ = new Aspose.Slides.Presentation(__inputPath__);

            // Compress embedded fonts

            Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(__presentation__);

            // Save compressed presentation

            __presentation__.Save(__outputPath__, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose presentation

            __presentation__.Dispose();



            // File information (optional)

            System.IO.FileInfo __fileInfoInput__ = new System.IO.FileInfo(__inputPath__);

            System.IO.FileInfo __fileInfoOutput__ = new System.IO.FileInfo(__outputPath__);

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            // Format not supported

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

