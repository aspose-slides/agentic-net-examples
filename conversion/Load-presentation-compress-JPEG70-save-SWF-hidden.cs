// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load presentation compress JPEG70 save SWF hidden using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation, compress JPEG images to

// quality 70, include hidden slides, and save the result as an SWF file using

// Aspose.Slides for .NET. The example shows the required steps for processing

// PPTX files and generating SWF output in a console application.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Presentation, Compress,

// JPEG70, ShowHiddenSlides, SWF, Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PPTX to SWF while compressing images to reduce file size.

// - Include hidden slides in the exported SWF for complete content delivery.

// - Build C# utilities for batch conversion of presentations with image

//   compression and hidden slide handling.

// - Validate and automate PowerPoint workflows before publishing.

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

        string outputPath = "output.swf";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            Presentation presentation = new Presentation(inputPath);

            SwfOptions swfOptions = new SwfOptions

            {

                Compressed = true,

                JpegQuality = 70,

                ShowHiddenSlides = true

            };



            presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

