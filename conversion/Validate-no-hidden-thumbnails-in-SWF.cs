// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate no hidden thumbnails in SWF using C#

//

// Description:

// Demonstrates how to hide a slide in a PowerPoint presentation and save the

// file as SWF while ensuring hidden slide thumbnails are excluded. The example

// uses Aspose.Slides for .NET to load a PPTX, optionally hide the first slide,

// persist the changes to a new PPTX, configure SWF export options to omit

// hidden slides, and generate the SWF output. This pattern can be used to

// validate that hidden content does not appear in SWF thumbnails.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Validate, Hidden, Thumbnails,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Verify that hidden slides are not rendered as thumbnails in SWF output.

// - Automate PowerPoint to SWF conversion while respecting slide visibility.

// - Build validation tools for presentation workflows before publishing.

// - Integrate slide visibility checks into .NET applications handling PPTX files.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Input presentation path

        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");

        // Output SWF path

        string outputSwfPath = Path.Combine(Environment.CurrentDirectory, "output.swf");

        // Optional output PPTX path to verify changes

        string outputPptxPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");



        // Verify input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            Presentation pres = new Presentation(inputPath);



            // Hide the first slide (if any) to test hidden slide handling

            if (pres.Slides.Count > 0)

            {

                pres.Slides[0].Hidden = true;

            }



            // Save the modified presentation (optional, ensures changes are persisted)

            pres.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);



            // Configure SWF options to exclude hidden slides

            SwfOptions swfOptions = new SwfOptions();

            swfOptions.ShowHiddenSlides = false;



            // Save as SWF; hidden slide thumbnails will not be included

            pres.Save(outputSwfPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);



            Console.WriteLine("SWF saved without hidden slide thumbnails.");

        }

        catch (Exception ex)

        {

            // Handle errors such as unsupported format

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

