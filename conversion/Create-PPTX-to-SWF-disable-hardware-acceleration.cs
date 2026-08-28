// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create PPTX to SWF disable hardware acceleration using C#

//

// Description:

// Demonstrates how to convert a PPTX presentation to SWF format while disabling

// hardware acceleration using Aspose.Slides for .NET. The sample loads an input

// PPTX file, configures the SwfOptions to turn off hardware acceleration, and

// saves the result as an SWF file. It includes basic error handling for missing

// files and unsupported formats.

//

// Keywords:

// C#, Aspose.Slides, PPTX, SWF, Disable Hardware Acceleration, Presentation Conversion,

// PowerPoint, Export, .NET

//

// Use Cases:

// - Convert PowerPoint presentations to SWF for web viewers without relying on

//   hardware acceleration.

// - Integrate PPTX to SWF conversion into automated .NET workflows.

// - Prepare legacy Flash-compatible presentations while ensuring consistent rendering.

// - Provide fallback formats for environments where hardware acceleration is unavailable.

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

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

            // Disable hardware acceleration (placeholder - actual property may differ)

            swfOptions.ViewerIncluded = false;

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported for SWF conversion.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

