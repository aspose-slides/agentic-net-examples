// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Disable viewer UI in SWF for third‑party using C#

//

// Description:

// Demonstrates how to disable the integrated viewer UI when converting a PowerPoint

// presentation to SWF format using Aspose.Slides for .NET. The example loads a PPTX

// file, configures SwfOptions to exclude the viewer, and saves the result as a SWF

// file. This pattern is useful for generating SWF files intended for third‑party

// viewers that provide their own UI.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Disable Viewer UI, Third‑party,

// Presentation Conversion, Office Automation

//

// Use Cases:

// - Convert PPTX to SWF without the built‑in viewer for integration with custom players.

// - Automate batch processing of presentations for third‑party distribution.

// - Build .NET tools that prepare presentation assets for external platforms.

// - Ensure SWF output complies with external UI requirements.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Determine input file path

        string inputFile = args.Length > 0 && !String.IsNullOrEmpty(args[0]) ? args[0] : "input.pptx";



        // Verify that the input file exists

        if (!File.Exists(inputFile))

        {

            Console.WriteLine("Input file does not exist: " + inputFile);

            return;

        }



        // Prepare output file path

        string outputDirectory = Path.GetDirectoryName(inputFile) ?? "";

        string outputFileName = Path.GetFileNameWithoutExtension(inputFile) + "_noViewer.swf";

        string outputFile = Path.Combine(outputDirectory, outputFileName);



        try

        {

            // Load the presentation

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile))

            {

                // Configure SWF options to disable the integrated viewer UI

                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

                swfOptions.ViewerIncluded = false;



                // Save the presentation as SWF with the specified options

                presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

            }

        }

        catch (Exception ex)

        {

            // Handle errors such as unsupported format or other processing issues

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

