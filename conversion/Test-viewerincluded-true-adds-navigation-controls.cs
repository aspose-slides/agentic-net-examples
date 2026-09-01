// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Test viewerincluded true adds navigation controls using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation to SWF format with

// the ViewerIncluded option set to true, which embeds a viewer containing

// navigation controls. The example uses Aspose.Slides for .NET to load an

// input PPTX file, configure SwfOptions, and save the output SWF file.

// This pattern can be used to generate self‑contained SWF presentations

// with built‑in navigation for web viewing.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, ViewerIncluded, Navigation Controls, Conversion

//

// Use Cases:

// - Generate SWF files with embedded viewer for web distribution.

// - Add navigation controls to converted presentations automatically.

// - Automate batch conversion of PPTX to SWF with viewer support.

// - Integrate presentation conversion into .NET applications.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        var inputPath = "input.pptx";

        var outputPath = "output.swf";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            using (var pres = new Presentation(inputPath))

            {

                var options = new SwfOptions();

                options.ViewerIncluded = true; // Include viewer with navigation controls



                pres.Save(outputPath, SaveFormat.Swf, options);

            }

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

