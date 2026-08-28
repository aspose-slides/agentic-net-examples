// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Test viewerincluded false loads in HTML5 player using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation and save it as SWF

// with the ViewerIncluded option set to false (and true for comparison) using

// Aspose.Slides for .NET. This allows testing how the generated SWF behaves

// when the integrated viewer is excluded, which is relevant for HTML5 player

// scenarios.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Test, ViewerIncluded, False,

// Loads, HTML5, SWF, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate testing of ViewerIncluded false behavior in HTML5 players.

// - Generate SWF files with and without the integrated viewer for comparison.

// - Integrate PowerPoint to SWF conversion into .NET automation pipelines.

// - Validate presentation conversion settings before deployment.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Define input presentation path

        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file not found: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            using (Presentation presentation = new Presentation(inputPath))

            {

                // Create SWF options with ViewerIncluded set to false

                SwfOptions swfOptions = new SwfOptions();

                swfOptions.ViewerIncluded = false;



                // Save SWF without integrated viewer

                string outputSwfNoViewer = Path.Combine(Directory.GetCurrentDirectory(), "output_no_viewer.swf");

                presentation.Save(outputSwfNoViewer, SaveFormat.Swf, swfOptions);



                // Optionally, save SWF with integrated viewer for comparison

                swfOptions.ViewerIncluded = true;

                string outputSwfWithViewer = Path.Combine(Directory.GetCurrentDirectory(), "output_with_viewer.swf");

                presentation.Save(outputSwfWithViewer, SaveFormat.Swf, swfOptions);

            }

        }

        catch (Exception ex)

        {

            // Handle errors such as unsupported format

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

