// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load presentation set compression viewer UI swf using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation and save it as a compressed

// SWF file with the viewer UI included using Aspose.Slides for .NET. The example

// shows the necessary steps to open a PPTX file, configure SWF export options,

// and generate a standalone SWF output.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Presentation, 

// Compression, Viewer UI, SWF, Export, Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PPTX files to compressed SWF format with built‑in viewer UI.

// - Build C# utilities for PowerPoint to SWF conversion.

// - Automate generation of SWF files for web presentation viewers.

// - Validate and test SWF export settings in .NET applications.

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

            using (Presentation presentation = new Presentation(inputPath))

            {

                SwfOptions swfOptions = new SwfOptions();

                swfOptions.Compressed = true; // enable compression

                swfOptions.ViewerIncluded = true; // include viewer UI



                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

            }

        }

        catch (NotSupportedException)

        {

            // format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

